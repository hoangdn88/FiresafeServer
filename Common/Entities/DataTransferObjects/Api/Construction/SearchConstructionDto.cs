using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchConstructionDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public LocationInfoDto Location { get; set; }
        public string PcccUnitId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? IndustryField { get; set; }
        public int? ActivityType { get; set; }
        public string LocationDetail { get; set; }
    }
}
