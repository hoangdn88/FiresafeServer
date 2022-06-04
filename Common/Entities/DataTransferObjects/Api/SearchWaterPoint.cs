using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchWaterPoint
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string PcccUnitId { set; get; }
        public LocationInfo Location { set; get; }
    }
}
