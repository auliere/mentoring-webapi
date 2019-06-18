using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using GenFu;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class EventMemoryRepository : IRepository<Event>
    {
        private List<Event> events;

        public EventMemoryRepository()
        {
            long i = 1;
            GenFu.GenFu.Configure<Event>()
                .Fill(e => e.Id, i++);
            events = A.ListOf<Event>();
        }

        public IQueryable<Event> Get()
        {
            return events.AsQueryable();
        }

        public IQueryable<Event> Get(Func<Event, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Any(Func<Event, bool> predicate)
        {
            return events.Any(predicate);
        }

        public Event Edit(Event item)
        {
            if (item.Id == null)
                return null;
            var position = events.FindIndex(d => d.Id == item.Id);
            if (position < 0)
                return null;
            events[position] = item;
            return item;
        }

        public Event Add(Event item)
        {
            item.Id = item.Id ?? events.Max(d => d.Id) + 1;
            events.Add(item);
            return item;
        }

        public Event Remove(Func<Event, bool> predicate)
        {
            var item = events.SingleOrDefault(predicate);
            if (item == null)
                return null;
            events.Remove(item);
            return item;
        }
    }
}