using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public  class SearchReportConstructionCheckingDto
    {
        public LocationInfoDto Location { set; get; }
        public string PcccUnitId { set; get; }
        public int? JobType { set; get; }
        public int? ConstructionType { set; get; }
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }
        public string Name { set; get; }
        public List<string> ConstructionIds { set; get; }

    }
}
