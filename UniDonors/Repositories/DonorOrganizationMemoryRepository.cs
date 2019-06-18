using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class DonorOrganizationMemoryRepository : IRepository<DonorOrganization>
    {
        private List<DonorOrganization> donorsOrganizations;

        public DonorOrganizationMemoryRepository()
        {
            GenFu.GenFu.Configure<DonorOrganization>()
                .Fill(od => od.DonorId).WithRandom(Enumerable.Range(1, 25).Select(o => (long) o))
                .Fill(od => od.OrganizationId).WithRandom(Enumerable.Range(1, 25).Select(o => (long) o));
            donorsOrganizations = A.ListOf<DonorOrganization>(10);
        }

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
