using Common.Entities.Enum;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.Models
{
    public class PcccUnitInfo : GeoBase
    {
        public string Name { get; set; } // Tên đơn vị
        public string Code { get; set; } // Mã đơn vị
        public string PhoneNumber { get; set; } // Số điện thoại đơn vị
        public string PhoneNumberHotline { get; set; } // Số điện thoại trực đơn vị
        public string ManagerId { get; set; } // Cục trưởng đơn vị
        public string Email { get; set; } // Mail đơn vị
        public int? WaterPointCount { get; set; } // Số điểm lấy nước
        public int? ManagerCount { get; set; } // Số nhân sự quản lý
        public int? FireSaferCount { get; set; } // Số nhân sự chữa cháy
        public UnderType? Type { get; set; } // loại hình đơn vị

        public PcccUnitInfo() : base()
        {

        }
    }

}
