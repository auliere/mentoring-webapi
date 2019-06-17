using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniDonors.Models;

namespace UniDonors.Repositories
{
    public class DonorMemoryRepository : IRepository<Donor>
    {
        private List<Donor> donors = new List<Donor>
        {
            new Donor
            {
                Id = 1,
                BirthDate = new DateTime(1995, 8, 8),
                IsEligible = true,
                BloodType = BloodTypeEnum.O,
                RhesusType = RhesusTypeEnum.Negative,
                FirstName = "Oleh",
                LastName = "Pedorenko",
                Email = "oleh.pedorenko@gmail.com",
                DonorType = DonorTypeEnum.Student
            },
            new Donor
            {
                Id = 2,
                BirthDate = new DateTime(1995, 10, 8),
                IsEligible = true,
                BloodType = BloodTypeEnum.O,
                RhesusType = RhesusTypeEnum.Positive,
                FirstName = "Olexiy",
                LastName = "Demidenko",
                MiddleName = "Oleksandrovich",
                Email = "oleh.pedorenko@gmail.com",
                DonorType = DonorTypeEnum.Stranger
            }
        };

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
