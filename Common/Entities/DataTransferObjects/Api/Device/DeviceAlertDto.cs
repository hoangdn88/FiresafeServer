using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceAlertDto
    {
        public string Imei { set; get; } // IMEI thiết bị
        public DateTime DeviceTime { set; get; } // Thời gian ở thiết bị
        public string ConstructionId { set; get; }
        public List<AlertType> AlertState { set; get; } // Trạng thái cảnh báo
        public int? InTestMode { set; get; }
    }
}
