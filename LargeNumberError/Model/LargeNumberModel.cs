using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWNet.Data;

namespace LargeNumberError.Model
{
    
    [DataWindow("largenumbermodel",DwStyle.Grid)]
    [DwSelect("Select 12.1234567890123456789012345678 From dual")]
    public class LargeNumberModel
    {
        [DwColumn("largenumber")]
        public decimal? LargeNumber { get; set; }
    }
}
