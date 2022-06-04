using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models.Device
{
    public class DeviceHistoryInfo : Base
    {
        public string Imei { set; get; } // IMEI thiết bị
        public string MacAddress { set; get; } // Địa chỉ mac của thiết bị
        public string SimImei { set; get; } // IMEI SIM lắp trong thiết bị
        public string Firmware { set; get; } // Phiên bản firmware
        public string ConstructionId { set; get; }
        public List<AlertType> AlertState { set; get; } // Trạng thái cảnh báo
        public int? BatteryPercent { set; get; } // % pin
        public DateTime? CreateTime { set; get; } // Thời điểm tạo thông tin lịch sử
        public DeviceStatus? Status { set; get; } // Trạng thái thiết bị on/off
        public BatteryStatus? BatteryStatus { set; get; } // trạng thái pin
        public int? InTestMode { set; get; } // Chế độ test
    }
}
