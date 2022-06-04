using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class ConstructionCheckingReportDto
    {
        public LocationInfo Location { get; set; }
        public PcccUnitDto PcccUnit { get; set; }
        public string Decision { get; set; }
    }
}
