using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SupportUnitDto : GeoBaseDto
    {
        public string Id { get; set; } // Id đơn vị
        [JsonPropertyName("MaDonVi")]
        public string Code { set; get; } // Mã đơn vị hỗ trợ
        [JsonPropertyName("Tendonvi")]
        public string Name { set; get; } // Tên vị hỗ trợ
        [JsonPropertyName("SoDienThoai")]
        public string PhoneNumber { set; get; } // Số điện thoại đơn vị hỗ trợ
        [JsonPropertyName("LoaiDonVi")]
        public SupportUnitType? Type { set; get; } // Loại đơn vị hỗ trợ
        //public LocationInfoDto Location { set; get; } // Vị trí đơn vị hỗ trợ     
        public string PcccUnitId { get; set; } // Trực thuộc đơn vị
    }
}
