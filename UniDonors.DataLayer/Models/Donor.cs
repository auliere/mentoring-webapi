﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.DataLayer.Models
{
    public class Donor
    {
        public long? Id { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool? IsEligible { get; set; }
        public string Notes { get; set; }
        public DonorTypeEnum? DonorType { get; set; }
        public BloodTypeEnum? BloodType { get; set; }
        public RhesusTypeEnum? RhesusType { get; set; }
    }
}
