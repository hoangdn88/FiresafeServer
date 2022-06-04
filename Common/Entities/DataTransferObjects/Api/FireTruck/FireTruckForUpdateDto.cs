using Common.Entities.Enum;
using Common.Entities.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FireTruckForUpdateDto : UpdateBase
    {
        [JsonPropertyName("TenPhuongTien")]
        public string Name { get; set; } // Tên phương tiện
        [JsonPropertyName("LoaiPhuongTien")]
        
        public FireTruckType? Type { get; set; } // Loại phương tiện
        [JsonPropertyName("SoHieuPhuongTien")]
        public string VIN { get; set; } // Số hiệu phương tiện
        [JsonPropertyName("TinhTrangHoatDong")]
        public WorkingStatus? Status { get; set; } // Tình trạng phương tiện
        [JsonPropertyName("BienSo")]
        public string PlateNumber { get; set; } // Biển số xe
        public LocationInfoDto Location { get; set; } // Địa điểm
        [JsonPropertyName("TrucThuoc")]
        
        public UnderType? Under { get; set; } // Trực thuộc đơn vị
        [Required]
        [JsonPropertyName("DonVi")]
        public string PcccUnitId { get; set; } // Đơn vị PCCC
        [JsonPropertyName("SoDienThoai")]
        public string PhoneNumber { get; set; } // Số điện thoại liên hệ
        [JsonPropertyName("Imei")]
        public string IMEI { get; set; } // Mã IMEI
        public List<string> Users { get; set; } // Người sử dụng phương tiện
        public AvailabilityStatus? Available { get; set; } // Tình trạng sẵn sàng 
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }
        public string LocationDetail { get; set; } // Địa chỉ chi tiết
        public string FireProtectionId { get; set; } // Id vụ cháy đang tham gia
        public string Manager { get; set; } // Nhân sự quản lý
        public DateTime? UsedDate { get; set; } // Ngày đưa vào sử dụng
        public DateTime? ExpireDate { get; set; } // Ngày hết hạn
    }
}
