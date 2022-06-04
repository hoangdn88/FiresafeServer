using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class SensorSearchDto
    {
        public string Id { get; set; }
        public string Mac { get; set; }
        public List<string> PairingDevice { get; set; }
        public string Info { get; set; }
        public DateTime? InstallFromTime { get; set; }
        public DateTime? InstallToTime { get; set; }
        public SensorType? Type { set; get; }
        public WorkingStatus? Status { set; get; }
        public string SerialNumber { set; get; }
        public List<string> ConstructionIds { get; set; }
        public string KeySearch { get; set; }
    }
}
