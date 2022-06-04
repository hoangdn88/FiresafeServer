using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models.Device
{
    public class DeviceInfo : Base
    {
        public string Imei { set; get; } // IMEI thiết bị
        public string Name { set; get; }
        public string SeriNumber { set; get; }
        public string LoaiThietBi { set; get; }
        public string ConstructionId { set; get; }
        public bool? IsActive { set; get; }
        public DateTime? CreateTime { set; get; } // Thời gian tạo
        public DateTime? UpdateTime { set; get; } // Thời gian cập nhật dữ liệu
        public DateTime? ActiveTime { set; get; } // Thời gian bắt đầu kích hoạt (dùng để tính thu phí)
        public DateTime? ExpiredTime { set; get; } // Thời điểm hết hạn

        public DeviceHardwareInfo Status { set; get; }
    }
}
