using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Alert
{
    public class UserAlertDto
    {        
        public string Id { get; set; }
        public string ConstructionId { set; get; }
        public string PcccUnitId { set; get; }
        public FireProcessStatus ProcessStatus { set; get; }
        public DateTime StartTime { set; get; }
    }
}
