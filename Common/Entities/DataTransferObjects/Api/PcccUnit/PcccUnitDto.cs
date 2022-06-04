using Common.Entities.Enum;
using Common.Entities.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class PcccUnitDto: LocationBase
    {
        public string Id { get; set; } // Id đơn vị

        [JsonPropertyName("TenDonVi")]
        public string Name { get; set; } // Tên đơn vị

        [JsonPropertyName("MaDonVi")]
        public string Code { get; set; } // Mã đơn vị

        //public LocationInfoDto Location { get; set; } // Vị trí đơn vị
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }

        public string PhoneNumber { get; set; } // Số điện thoại đơn vị

        [JsonPropertyName("SoDienThoaiTrucBan")]
        public string PhoneNumberHotline { get; set; } // Số điện thoại trực đơn vị

        [JsonPropertyName("CanBoQuanLy")]
        public string ManagerId { get; set; } // Cục trưởng đơn vị

        public string Email { get; set; } // Mail đơn vị
        
        [JsonPropertyName("SoDiemLayNuocQuanLy")]
        public int? WaterPointCount { get; set; } // Số điểm lấy nước

        [JsonPropertyName("SoNhanSuQuanLy")]
        public int? ManagerCount { get; set; } // Số nhân sự quản lý

        [JsonPropertyName("SoNhanSuChuaChay")]
        public int? FireSaferCount { get; set; } // Số nhân sự chữa cháy

        [JsonPropertyName("LoaiHinhDonVi")]        
        public UnderType? Type { get; set; } // loại hình đơn vị

        //[JsonPropertyName("DiaChi")]
        public string LocationDetail { get; set; } // Địa chỉ chi tiết
    }
}
