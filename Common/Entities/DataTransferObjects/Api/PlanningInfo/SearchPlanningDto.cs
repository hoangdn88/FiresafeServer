using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchPlanningDto
    {
        public string Name { set; get; }
        public LocationInfoDto Location { set; get; }
        public string PcccUnitId { set; get; }
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }
    }
}
