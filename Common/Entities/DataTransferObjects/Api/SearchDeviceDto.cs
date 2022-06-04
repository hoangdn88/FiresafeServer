using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchDeviceDto
    {
        public string PcccUnitId { set; get; }
        public LocationInfo Location { set; get; }
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }
    }
}
