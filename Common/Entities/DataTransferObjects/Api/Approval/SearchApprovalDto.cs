using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchApprovalDto
    {
        public string Name { get; set; }
        public LocationInfoDto Location { get; set; }
        public string ConstructionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public SolvingStatus? SolvingStatus { set; get; } // tình trạng xử lý
    }
}
