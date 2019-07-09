using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using UniDonors.DataLayer.Models;

namespace UniDonors.DataLayer.Repositories
{
    public class DonorMemoryRepository : IRepository<Donor>
    {
        private static List<Donor> donors;

        public DonorMemoryRepository()
        {
            var i = 1;
            GenFu.GenFu.Configure<Donor>()
                .Fill(d => d.MiddleName).AsFirstName()
                .Fill(d => d.Id, () => i++)
                .Fill(d => d.BloodType)
                .WithRandom(Enum.GetValues(typeof(BloodTypeEnum)).Cast<BloodTypeEnum?>())
                .Fill(d => d.DonorType)
                .WithRandom(Enum.GetValues(typeof(DonorTypeEnum)).Cast<DonorTypeEnum?>())
                .Fill(d => d.RhesusType)
                .WithRandom(Enum.GetValues(typeof(RhesusTypeEnum)).Cast<RhesusTypeEnum?>())
                .Fill(d => d.Email, d => $"{d.FirstName}.{d.LastName}@gmail.com")
                .Fill(d => d.BirthDate).AsPastDate()
                .Fill(d => d.Notes).AsLoremIpsumSentences();

            donors = A.ListOf<Donor>();
        }

        public Donor Add(Donor item)
        {
            item.Id = item.Id ?? donors.Max(d => d.Id) + 1;
            donors.Add(item);
            return item;
        }

        public bool Any(Func<Donor, bool> predicate)
        {
            return donors.Any(predicate);
        }

        public Donor Edit(Donor item)
        {
            if (item.Id == null)
                return null;
            var position = donors.FindIndex(d => d.Id == item.Id);
            if (position < 0)
                return null;
            donors[position] = item;
            return item;
        }

        public IQueryable<Donor> Get()
        {
            return donors.AsQueryable();
        }

        public IQueryable<Donor> Get(Func<Donor, bool> predicate)
        {
            return donors.Where(predicate).AsQueryable();
        }

        public Donor Remove(Func<Donor, bool> predicate)
        {
            var item = donors.SingleOrDefault(predicate);
            if (item == null)
                return null;
            donors.Remove(item);
            return item;
        }
    }
}
