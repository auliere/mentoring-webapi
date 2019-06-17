using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class DonorOrganizationMemoryRepository : IRepository<DonorOrganization>
    {
        private List<DonorOrganization> donorsOrganizations = new List<DonorOrganization>
        {
            new DonorOrganization { DonorId = 1, OrganizationId = 1 },
            new DonorOrganization { DonorId = 1, OrganizationId = 2 },
            new DonorOrganization { DonorId = 2, OrganizationId = 1 }
        };

        public DonorOrganization Add(DonorOrganization item)
        {
            donorsOrganizations.Add(item);
            return item;
        }

        public bool Any(Func<DonorOrganization, bool> predicate)
        {
            return donorsOrganizations.Any(predicate);
        }

        public DonorOrganization Edit(DonorOrganization item)
        {            
            var position = donorsOrganizations
                .FindIndex(d => d.DonorId == item.DonorId && d.OrganizationId == item.OrganizationId);
            if (position < 0)
                return null;
            donorsOrganizations[position] = item;
            return item;
        }

        public IQueryable<DonorOrganization> Get()
        {
            return donorsOrganizations.AsQueryable();
        }

        public IQueryable<DonorOrganization> Get(Func<DonorOrganization, bool> predicate)
        {
            return donorsOrganizations.Where(predicate).AsQueryable();
        }

        public DonorOrganization Remove(Func<DonorOrganization, bool> predicate)
        {
            var item = donorsOrganizations.SingleOrDefault(predicate);
            if (item == null)
                return null;
            donorsOrganizations.Remove(item);
            return item;
        }
    }
}
