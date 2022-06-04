using Common.Entities.DataTransferObjects;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models.Device
{
    public class SensorInfo : Base
    {
        public string SerialNumber { get; set; }
        public string Mac { set; get; }
        public string Firmware { set; get; }
        public WorkingStatus? Status { set; get; }
        public int? Battery { set; get; }
        public int? Temperature { set; get; }
        public int? Smoke { set; get; }
        public DateTime? UpdateTime { set; get; }
        public string PairingDevice { set; get; }
        public string InstallLocation { set; get; }
        public string Info { set; get; }
        public SensorType? Type { set; get; }
        public DateTime? InstalledTime { set; get; }
        public DateTime? CreateTime { set; get; }
        public DateTime? ExpiredTime { set; get; }

        public SensorInfo() : base()
        {
            Type = SensorType.CHUA_XAC_DINH;            
        }

        public SensorInfo(SensorInfoDto sensorInfoDto)
        {
            Mac = sensorInfoDto.Mac;
            Firmware = sensorInfoDto.Firmware;
            Status = sensorInfoDto.Status;
            Battery = sensorInfoDto.Battery;
            Temperature = sensorInfoDto.Temperature;
            Smoke = sensorInfoDto.Smoke;
            UpdateTime = sensorInfoDto.UpdateTime;
        }
    }

    
}
