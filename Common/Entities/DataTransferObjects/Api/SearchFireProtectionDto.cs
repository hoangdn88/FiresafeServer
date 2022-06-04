using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchFireProtectionDto
    {
        public string Name { set; get; }
        public LocationInfoDto Location { set; get; }
        public string PcccUnitId { set; get; }
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }
        public List<string> ConstructionIds { set; get; }
        public FireProcessStatus? ProcessStatus { set; get; }
        public int? Reason { set; get; }
        public int? FromLossMoney { set; get; }
        public int? ToLossMoney { set; get; }
        public int? ConstructionType { set; get; }
        public int? JobType { set; get; }
        public int? Year { set; get; }
        public List<LocationInfoDto> LocationList { set; get; }
    }
}
