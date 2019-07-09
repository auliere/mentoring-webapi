using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniDonors.DataLayer.Models;
using UniDonors.DataLayer.Repositories;

namespace UniDonors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        ILogger<OrganizationsController> _logger;
        IRepository<Organization> _organizationRepository;

        public OrganizationsController(IRepository<Organization> organizationRepository, ILogger<OrganizationsController> logger)
        {
            _organizationRepository = organizationRepository;
            _logger = logger;
        }

        // GET api/Organizations
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_organizationRepository.Get().ToList());
        }

        // GET api/Organizations/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Organization = _organizationRepository
                .Get(o => o.Id == id)
                .FirstOrDefault();
            if (Organization == null)
                return NotFound();
            return Ok(Organization);
        }

        // POST api/Organizations
        [HttpPost]
        public IActionResult Post([FromBody]Organization value)
        {
            var organization = _organizationRepository.Add(value);
            return CreatedAtAction(nameof(Post), organization);
        }

        // PUT api/Organizations/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Organization value)
        {
            value.Id = id;
            var Organization = _organizationRepository.Edit(value);
            if (Organization == null)
            {
                _logger.LogInformation($"Organization with id {id} not found, creating a new Organization");
                Organization = _organizationRepository.Add(value);
            }
            return CreatedAtAction(nameof(Put), Organization);
        }

        // DELETE api/Organizations/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _organizationRepository.Remove(o => o.Id == id);
        }

    }
}
