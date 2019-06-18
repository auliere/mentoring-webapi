using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class OrganizationMemoryRepository : IRepository<Organization>
    {
        private List<Organization> organizations;

        public OrganizationMemoryRepository()
        {
            int i = 1;
            GenFu.GenFu.Configure<Organization>()
                .Fill(o => o.Id, () => i++)
                .Fill(o => o.Webpage, () => null);
            organizations = A.ListOf<Organization>();
        }

        public Organization Add(Organization item)
        {
            item.Id = item.Id ?? organizations.Max(d => d.Id) + 1;
            organizations.Add(item);
            return item;
        }

        public bool Any(Func<Organization, bool> predicate)
        {
            return organizations.Any(predicate);
        }

        public Organization Edit(Organization item)
        {
            if (item.Id == null)
                return null;
            var position = organizations.FindIndex(d => d.Id == item.Id);
            if (position < 0)
                return null;
            organizations[position] = item;
            return item;
        }

        public IQueryable<Organization> Get()
        {
            return organizations.AsQueryable();
        }

        public IQueryable<Organization> Get(Func<Organization, bool> predicate)
        {
            return organizations.Where(predicate).AsQueryable();
        }

        public Organization Remove(Func<Organization, bool> predicate)
        {
            var item = organizations.SingleOrDefault(predicate);
            if (item == null)
                return null;
            organizations.Remove(item);
            return item;
        }
    }
}
