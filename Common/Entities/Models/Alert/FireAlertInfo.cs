using Common.Entities.DataTransferObjects;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class FireAlertInfo : Base
    {
        public string DeviceImei { get; set; }
        public string DeviceName { get; set; }
        public CustomerInfo Customer { get; set; }
        public ConstructionInfo Construction { get; set; }
        public List<AlertType> AlertTypes { set; get; } // Trạng thái cảnh báo
        public DateTime StartTime { get; set; } // Thời gian bắt đầu
        public DateTime EndTime { get; set; } // Thời gian kết thúc
        public DateTime AlertDeviceTime { set; get; } // Thời gian ở thiết bị
        public DateTime AlertServerTime { set; get; } // Thời gian ở server
        public FireProcessStatus ProcessStatus { set; get; }
        public float TotalDamage { get; set; }
    }
}
