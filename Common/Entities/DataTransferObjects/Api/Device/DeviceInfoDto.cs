using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceInfoDto
    {
        public string Id { set; get; } // IMEI thiết bị
        public string Imei { set; get; } // IMEI thiết bị
        public string Name { set; get; }
        public string LoaiThietBi { set; get; }
        public bool? IsActive { set; get; }
        public string SeriNumber { set; get; }
        public ConstructionDto Construction { set; get; }
        public DateTime? CreateTime { set; get; } // Thời gian tạo
        public DateTime? UpdateTime { set; get; } // Thời gian cập nhật dữ liệu
        public DateTime? ActiveTime { set; get; } // Thời gian bắt đầu kích hoạt (dùng để tính thu phí)
        public DateTime? ExpiredTime { set; get; } // Thời điểm hết hạn
        public List<SensorInfoDto> Sensors { set; get; }

        public DeviceHardwareDto Status { set; get; }

        public string MonthOfYear { set; get; }
        public int? Count { set; get; }
    }
}
