using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using UniDonors.Models;
using UniDonors.Repositories;

namespace UniDonors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        ILogger<DonorsController> _logger;
        IRepository<Donor> _donorRepository;

        public DonorsController(IRepository<Donor> donorRepository, ILogger<DonorsController> logger)
        {
            _donorRepository = donorRepository;
            _logger = logger;
        }

        // GET api/donors
        [HttpGet]
        public IActionResult Get(
            [FromQuery(Name = "bloodType")]BloodTypeEnum? bloodType,
            [FromQuery(Name = "rhesusType")]RhesusTypeEnum? rhesusType
        )
        {
            return Ok(_donorRepository.Get(d => (bloodType == null || d.BloodType == bloodType) &&
                                             (rhesusType == null || d.RhesusType == rhesusType)).ToList());
        }

        // GET api/donors/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var donor = _donorRepository.Get(d => d.Id == id).FirstOrDefault();
            if (donor == null)
                return NotFound();
            return Ok(donor);
        }

        // POST api/donors
        [HttpPost]
        public IActionResult Post([FromBody]Donor value)
        {
            if (value == null)
            {
                Log.Warning($"No content in the body of the POST request to { Request.Path }");
                return BadRequest();
            }                
            value.Id = null;
            var donor = _donorRepository.Add(value);
            return CreatedAtAction(nameof(Post), donor);
        }

        // PUT api/donors/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Donor value)
        {
            value.Id = id;            
            var donor = _donorRepository.Edit(value);
            if (donor == null)
            {
                _logger.LogInformation($"Donor with id {id} not found, creating a new donor");
                donor = _donorRepository.Add(value);
            }                
            return CreatedAtAction(nameof(Put), donor);
        }

        // DELETE api/donors/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _donorRepository.Remove(d => d.Id == id);
        }
    }
}
