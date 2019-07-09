using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.DataLayer.Models
{
    public enum RhesusTypeEnum
    {
        [Description("+")]
        Positive,
        [Description("-")]
        Negative
    }
}
