using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public BloodTypeEnum? BloodTypeID { get; set; }
        public RhesusTypeEnum? RhesusID { get; set; }

    }
}
