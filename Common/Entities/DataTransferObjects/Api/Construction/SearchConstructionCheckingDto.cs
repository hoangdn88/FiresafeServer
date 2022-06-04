using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchConstructionCheckingDto
    {
        public string Content { get; set; }
        public string Name { get; set; }
        public string ConstructionCheckingPlanName { get; set; }
        public List<string> ConstructionCheckingPlanIds{ get; set; }
        public LocationInfoDto Location { get; set; }
        public List<string> ConstructionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public SolvingStatus? SolvingStatus { set; get; }
        public List<string> ConstructionPermissionId { get; set; }

    }
}
