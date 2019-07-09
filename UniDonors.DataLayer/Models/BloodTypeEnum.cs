using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.DataLayer.Models
{
    public enum BloodTypeEnum
    {
        [Description("I (O)")]
        O,
        [Description("II (A)")]
        A,
        [Description("III (B)")]
        B,
        [Description("IV (AB)")]
        AB
    }
}
