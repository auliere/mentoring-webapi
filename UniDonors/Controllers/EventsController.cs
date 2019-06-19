using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniDonors.Models;
using UniDonors.Repositories;

namespace UniDonors.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private IRepository<Event> eventRepository;

        public EventsController(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        // GET api/organizations/1/events
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(eventRepository.Get());
        }

        // GET api/organizations/1/events/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var ev = eventRepository.Get(e => e.Id == id);
            if (ev == null)
            {
                return NotFound();
            }

            return Ok(ev);
        }

        // POST api/organizations/1/events
        [HttpPost]
        public IActionResult Post([FromBody]Event value)
        {
            value.Id = null;
            var ev = eventRepository.Add(value);
            return CreatedAtAction(nameof(Get), new { id = ev.Id }, ev);
        }

        // PUT api/organizations/1/events/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Event value)
        {
            value.Id = id;
            var ev = eventRepository.Edit(value);
            if (ev == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new { id = ev.Id }, ev);
        }

        // DELETE api/organizations/1/events/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            eventRepository.Remove(e => e.Id == id);
        }

    }
}