using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.Models
{
    public enum DonorTypeEnum
    {
        [Description("Student")]
        Student,
        [Description("Employee")]
        Employee,
        [Description("Stranger")]
        Stranger
    }
}
