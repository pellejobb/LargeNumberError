using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWNet.Data;

namespace LargeNumberError.Model
{
    
    [DataWindow("largenumbermodel",DwStyle.Grid)]
    [DwSelect("Select 12.123456789012345678901234567 From dual")]
    public class LargeNumberModel
    {
        [DwColumn("largenumber")]
        public decimal? LargeNumber { get; set; }
    }
}
