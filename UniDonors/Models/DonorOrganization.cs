using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.Models
{
    public class DonorOrganization
    {
        [FromRoute(Name="donorId")]
        public long DonorId { get; set; }
        [FromRoute(Name="organizationId")]
        public long OrganizationId { get; set; }
    }
}
