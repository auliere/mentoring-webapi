using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniDonors.DataLayer.Models;
using UniDonors.DataLayer.Repositories;

namespace UniDonors.Controllers
{
    [ApiController]
    [Route("api")]
    public class DonorOrganizationController: ControllerBase
    {
        private IRepository<Donor> _donorRepository;
        private IRepository<Organization> _organizationRepository;
        private IRepository<DonorOrganization> _donorOrganizationRepository;

        public DonorOrganizationController(
            IRepository<Donor> donorRepository, 
            IRepository<Organization> organizationRepository,
            IRepository<DonorOrganization> donorOrganizationRepository)
        {
            _donorRepository = donorRepository;
            _organizationRepository = organizationRepository;
            _donorOrganizationRepository = donorOrganizationRepository;
        }

        [HttpGet("donors/{donorId}/organizations")]
        public IActionResult GetOrganizationsForDonor(long donorId)
        {
            if (!_donorRepository.Any(donor => donor.Id == donorId))
                return NotFound();
            var orgIds = _donorOrganizationRepository
                .Get(item => item.DonorId == donorId)
                .Select(item => item.OrganizationId)
                .ToList();
            var orgs = _organizationRepository
                .Get(org => orgIds.Contains(org.Id.Value));
            return Ok(orgs.ToList());
        }

        [HttpGet("organizations/{orgId}/donors")]
        public IActionResult GetDonorsForOrganization(long orgId)
        {
            if (!_organizationRepository.Any(org => org.Id == orgId))
                return NotFound();
            var donorIds = _donorOrganizationRepository
                .Get(item => item.OrganizationId == orgId)
                .Select(item => item.DonorId)
                .ToList();
            var donors = _donorRepository
                .Get(donor => donorIds.Contains(donor.Id.Value));
            return Ok(donors);
        }

        [HttpPost("organizations/{organizationId}/donors/{donorId}")]
        [HttpPut("organizations/{organizationId}/donors/{donorId}")]
        public IActionResult SetDonorForOrganization(DonorOrganization donorOrganization)
        {
            if (!_organizationRepository
                .Any(org => org.Id == donorOrganization.OrganizationId))
                return NotFound();
            if (!_donorRepository
                .Any(donor => donor.Id == donorOrganization.DonorId))
                return BadRequest();
            if (_donorOrganizationRepository
                .Any(od => od.DonorId == donorOrganization.DonorId && 
                           od.OrganizationId == donorOrganization.OrganizationId))
                return Ok();

            _donorOrganizationRepository.Add(donorOrganization);
            return Ok();
        }

        [HttpPost("donors/{donorId}/organizations/{organizationId}")]
        [HttpPut("donors/{donorId}/organizations/{organizationId}")]
        public IActionResult SetOrganizationForDonor(DonorOrganization donorOrganization)
        {
            if (!_donorRepository
                .Any(donor => donor.Id == donorOrganization.DonorId))
                return NotFound();
            if (!_organizationRepository
                .Any(org => org.Id == donorOrganization.OrganizationId))
                return BadRequest();
            if (_donorOrganizationRepository
                .Any(od => od.DonorId == donorOrganization.DonorId &&
                           od.OrganizationId == donorOrganization.OrganizationId))
                return Ok();

            _donorOrganizationRepository.Add(donorOrganization);
            return Ok();
        }

        [HttpDelete("donors/{donorId}/organizations/{organizationId}")]
        [HttpDelete("organizations/{organizationId}/donors/{donorId}")]
        public IActionResult DeleteDonorOrganization(DonorOrganization donorOrganization)
        {
            _donorOrganizationRepository
                .Remove(od => od.DonorId == donorOrganization.DonorId &&
                              od.OrganizationId == donorOrganization.OrganizationId);
            return Ok();
        }
    }
}
