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
        public IEnumerable<Event> Get()
        {
            eventRepository.Get();
        }

        // GET api/organizations/1/events/5
        [HttpGet("{id}")]
        public IEnumerable<Event> Get(long id)
        {
            return eventRepository.Get(e => e.Id == id);
        }

        // POST api/organizations/1/events
        [HttpPost]
        public void Post([FromBody]Event value)
        {
            throw new NotImplementedException();
        }

        // PUT api/organizations/1/events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/organizations/1/events/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

    }
}