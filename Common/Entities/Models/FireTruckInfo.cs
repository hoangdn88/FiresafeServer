using Common.Entities.Enum;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.Models
{
    public class FireTruckInfo : GeoBase
    {
        public string Name { get; set; } // Tên phương tiện
        
        public FireTruckType? Type { get; set; } // Loại phương tiện
        public string VIN { get; set; } // Số hiệu phương tiện
        public WorkingStatus? Status { get; set; } // Tình trạng phương tiện
        public AvailabilityStatus? Available { get; set; } // Tình trạng sẵn sàng 
        public string PlateNumber { get; set; } // Biển số xe      
        public UnderType? Under { get; set; } // Trực thuộc đơn vị
        public string PcccUnitId { get; set; } // Đơn vị PCCC
        public string PhoneNumber { get; set; } // Số điện thoại liên hệ
        public string IMEI { get; set; } // Mã IMEI
        public List<string> Users { get; set; } // Người sử dụng phương tiện
        public string FireProtectionId { get; set; } // Id vụ cháy đang tham gia
        public string Manager { get; set; } // Nhân sự quản lý
        public DateTime? UsedDate { get; set; } // Ngày đưa vào sử dụng
        public DateTime? ExpireDate { get; set; } // Ngày hết hạn

        public FireTruckInfo() : base()
        {

        }
    }
}
