using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniDonors.Models;

namespace UniDonors.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        // GET api/organizations/1/events
        [HttpGet]
        public IEnumerable<Event> Get(long organizationId)
        {
            return null;
        }

        // GET api/organizations/1/events/5
        [HttpGet("{id}")]
        public Event Get(long organizationId, long id)
        {
            throw new NotImplementedException();
        }

        // POST api/organizations/1/events
        [HttpPost]
        public void Post(long organizationId, [FromBody]Event value)
        {
            throw new NotImplementedException();
        }

        // PUT api/organizations/1/events/5
        [HttpPut("{id}")]
        public void Put(long organizationId, int id, [FromBody]Event value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/organizations/1/events/5
        [HttpDelete("{id}")]
        public void Delete(long organizationId, long id)
        {
            throw new NotImplementedException();
        }

    }
}