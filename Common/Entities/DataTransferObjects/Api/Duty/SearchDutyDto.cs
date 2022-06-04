using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchDutyDto
    {
        public string Note { get; set; }
        public string PcccUnitId { get; set; }
        public LocationInfoDto Location { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
