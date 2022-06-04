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
    public class FireFighterCreationDto
    {
        [JsonPropertyName("CbcsID")]
        public string Code { get; set; } // Mã số cán bộ ngành

        [JsonPropertyName("HoTen")]
        public string Name { get; set; } // Họ Tên 

        [JsonPropertyName("NgaySinh")]
        public DateTime? Birthday { get; set; } // Ngày sinh

        [JsonPropertyName("ChucVu")]        
        public PositionType? Position { get; set; } // Chức vụ
        
        [JsonPropertyName("CapBac")]        
        public RankType? Rank { get; set; } // Cấp bậc

        [JsonPropertyName("TrucThuoc")]        
        public UnderType? Under { get; set; } // Trực thuộc đơn vị

        [JsonPropertyName("DonVi")]
        public string PcccUnitId { get; set; } // Trực thuộc đơn vị

        [JsonPropertyName("SoDienThoai")]
        public string PhoneNumber { get; set; } // Ngày sinh

        [JsonPropertyName("CMTNhanDan")]
        public string Passport { get; set; } // Mã cmtnd

        [JsonPropertyName("NgayBatDauLamViec")]
        public DateTime? StartOfWorkDate { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("ChucNangCongViec")]
        public string Function { get; set; } // Chức năng công việc
        public LocationInfoDto Location { get; set; }
    }
}
