using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class WaterPointInfo : GeoBase
    {
        public string Code { set; get; } // Mã điểm lấy nước
        public string Name { set; get; } // Tên điểm lấy nước
        public string PcccUnitId { set; get; } // Đơn vị quản lý
        public string Type { set; get; } // Loại
        public string PhoneNumber { set; get; } // Số điện thoại
        public string Description { set; get; } // Mô tả
        public bool? WaterForFireTruck { set; get; } // Khả năng cung cấp nước cho xe chữa cháy
        public string Importance { set; get; } // Độ quan trọng

        public WaterPointInfo() : base()
        {
        } 
    }
}
