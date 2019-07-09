using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.DataLayer.Models
{
    public class Organization
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Webpage { get; set; }
        public string Email { get; set; }
    }
}
