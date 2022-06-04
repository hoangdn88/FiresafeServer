using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class SensorCreationDto
    {
        public string SerialNumber { get; set; }
        public string Mac { get; set; }
        public string InstallLocation { set; get; }
        public string PairingDevice { get; set; }
        public string Info { get; set; }
        public DateTime? InstalledTime { get; set; }
        public DateTime? ExpiredTime { set; get; }
        public SensorType? Type { set; get; }
        public WorkingStatus? Status { set; get; }

    }
}
