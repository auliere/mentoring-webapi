using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniDonors.Models;
using UniDonors.Repositories;

namespace UniDonors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IRepository<Event> eventRepository;

        public EventsController(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        // GET api/events
        [HttpGet]
        public IActionResult Get()
        {
            // return Ok(eventRepository.Get());
            return Ok(eventRepository.Get().ToList());
        }

        // GET api/events/event5
        [HttpGet("{id:eventId}")]
        public IActionResult Get(string id)
        {
            var ev = eventRepository.Get(e => e.Id == id).SingleOrDefault();
            if (ev == null)
            {
                return NotFound();
            }

            return Ok(ev);
        }

        // POST api/events
        [HttpPost]
        public IActionResult Post([FromBody]Event value)
        {
            value.Id = null;
            var ev = eventRepository.Add(value);
            return CreatedAtAction(nameof(Get), new { id = ev.Id }, ev);
        }

        // PUT api/events/event5
        [HttpPut("{id:eventId}")]
        public IActionResult Put(string id, [FromBody]Event value)
        {
            value.Id = id;
            var ev = eventRepository.Edit(value);
            if (ev == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new { id = ev.Id }, ev);
        }

        // DELETE api/events/event5
        [HttpDelete("{id:eventId}")]
        public void Delete(string id)
        {
            eventRepository.Remove(e => e.Id == id);
        }

    }
}