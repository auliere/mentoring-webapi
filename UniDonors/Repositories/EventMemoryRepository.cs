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
        private long indexer = 1;
        private string idFormat = "event{0}";

        public EventMemoryRepository()
        {
            GenFu.GenFu.Configure<Event>()
                .Fill(e => e.Id, () => { return String.Format(idFormat, indexer++); });
            events = A.ListOf<Event>();
        }

        public IQueryable<Event> Get()
        {
            return events.AsQueryable();
        }

        public IQueryable<Event> Get(Func<Event, bool> predicate)
        {
            return events.Where(predicate).AsQueryable();
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
            item.Id = item.Id ?? String.Format(idFormat, indexer++);
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