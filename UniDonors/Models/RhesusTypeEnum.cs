using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UniDonors.Models
{
    public enum RhesusTypeEnum
    {
        [Description("+")]
        Positive,
        [Description("-")]
        Negative
    }
}
