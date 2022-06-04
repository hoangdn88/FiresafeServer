using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchDataReportFireTruckDto
    {
        public LocationInfoDto Location { set; get; }
        public string PcccUnitId { set; get; }
        public int? Type { set; get; }
        public int? Status { set; get; }
        public List<LocationInfoDto> LocationList { set; get; }
    }
}
