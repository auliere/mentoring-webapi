using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class OrganizationMemoryRepository : IRepository<Organization>
    {
        private List<Organization> organizations = new List<Organization>
        {
            new Organization
            {
                Id = 1,
                Address = "Zhylianska 75",
                Description = "Good guys",
                Email = "epam@epam.com",
                Name = "EPAM Systems",
                Phone = "+380123341234",
                Webpage = "http://www.epam.com/"
            },
            new Organization
            {
                Id = 2,
                Address = "Peremohy Ave 118",
                Description = "Also good guys",
                Email = "sss.ntuu.kpi@gmail.com",
                Name = "SSS NTUU KPI",
                Phone = "+380445255565",
                Webpage = "http://www.sss.kpi.ua/"
            },
        };

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
