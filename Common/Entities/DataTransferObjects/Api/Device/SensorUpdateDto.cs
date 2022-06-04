using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class SensorUpdateDto
    {
        [Required]
        public string Id { get; set; }
        public string Mac { get; set; }
        public string SerialNumber { get; set; }
        public WorkingStatus? Status { set; get; }
        public string ConstructionId { set; get; }
        public string PairingDevice { set; get; }
        public string InstallLocation { set; get; }
        public string Info { set; get; }
        public SensorType? Type { set; get; }
        public DateTime? InstalledTime { set; get; }
        public DateTime? ExpiredTime { set; get; }
    }
}
