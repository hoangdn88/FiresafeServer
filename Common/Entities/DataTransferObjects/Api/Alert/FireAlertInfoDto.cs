using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Alert
{
    public class FireAlertInfoDto
    {     
        public string Id { get; set; }
        public string DeviceImei { get; set; }
        public string DeviceName { get; set; }
        public CustomerInfo Customer { get; set; }
        public ConstructionDto Construction { get; set; }
        public List<AlertType> AlertTypes { set; get; } // Trạng thái cảnh báo
        public DateTime StartTime { get; set; } // Thời gian bắt đầu
        public DateTime EndTime { get; set; } // Thời gian kết thúc
        public DateTime AlertDeviceTime { set; get; } // Thời gian ở thiết bị
        public DateTime AlertServerTime { set; get; } // Thời gian ở server
        public FireProcessStatus ProcessStatus { set; get; }
        public float TotalDamage { get; set; }    
    }
}
