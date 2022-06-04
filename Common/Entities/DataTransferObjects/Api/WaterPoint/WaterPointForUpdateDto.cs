using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using Common.Entities.Models;

namespace Common.Entities.DataTransferObjects.Api
{
    public class WaterPointForUpdateDto : UpdateBase
    {
        [JsonPropertyName("MaDiem")]
        public string Code { set; get; } // Mã điểm lấy nước

        [JsonPropertyName("TenDiemLayNuoc")]
        public string Name { set; get; } // Tên điểm lấy nước
        public LocationInfoDto Location { set; get; } // Địa điểm
        public string PcccUnitId { set; get; } // Đơn vị quản lý
        public string Type { set; get; } // Loại

        public string PhoneNumber { set; get; } // Số điện thoại

        [JsonPropertyName("MoTa")]
        public string Description { set; get; } // Mô tả

        public bool? WaterForFireTruck { set; get; } // Khả năng cung cấp nước cho xe chữa cháy

        public string LocationDetail { set; get; } // Địa chỉ cụ thể

        [JsonPropertyName("DoQuanTrong")]
        public string Importance { set; get; } // Độ quan trọng

        public double? Longitude { set; get; } // Kinh độ

        public double? Latitude { set; get; } // Vĩ độ 
    }
}
