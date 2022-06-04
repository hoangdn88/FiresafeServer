using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using Common.Entities.Models;

namespace Common.Entities.DataTransferObjects.Api
{
    public class WaterPointForCreationDto : GeoBaseDto
    {
        [JsonPropertyName("MaDiem")]
        public string Code { set; get; } // Mã điểm lấy nước

        [JsonPropertyName("TenDiemLayNuoc")]
        public string Name { set; get; } // Tên điểm lấy nước

        public string PcccUnitId { set; get; } // Đơn vị quản lý

        public string Type { set; get; } // Loại

        public string PhoneNumber { set; get; } // Số điện thoại quản lý

        [JsonPropertyName("MoTa")]
        public string Description { set; get; } // Mô tả

        public bool? WaterForFireTruck { set; get; } // Khả năng cung cấp nước cho xe chữa cháy

        [JsonPropertyName("DoQuanTrong")]
        public string Importance { set; get; } // Độ quan trọng

    }
}
