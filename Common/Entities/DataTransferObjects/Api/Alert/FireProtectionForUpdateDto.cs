using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FireProtectionForUpdateDto : UpdateBase
    {
        public string DeviceName { set; get; } 
        public string FiringSource { set; get; } // Nguồn gây cháy
        public ExplosionType? ExplosionType { set; get; } // Loại cháy nổ
        public Area? Area { set; get; } // Khu vực
        public string ConstructionId { set; get; } // Cơ sở công trình
        public FireReason? Reason { set; get; } // Nguyên nhân cháy
        public int? InjuredCount { set; get; } // Số người bị thương
        public int? DeadCount { set; get; } // Số người chết
        public int? EstimateMoney { set; get; } // Số tiền ước tính thiệt hại
        public int? FiremanCount { set; get; } // Số CBCS tham gia chữa cháy
        public string Note { set; get; } // Ghi chú        
        public FireProcessStatus? ProcessStatus { set; get; }
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? FireAlarmTime { set; get; } // Thời gian báo cháy
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public string ProcessLog { set; get; } // Tình trạng xử lý
        public List<AlertType> AlertType { set; get; } // nguồn báo cháy
        public string Name { get; set; }
        public string PhoneNumber { set; get; } // Số điện thoại
        public string ReporterName { set; get; } // Tên người báo
        public LocationInfoDto Location { set; get; }
        public string LocationDetail { set; get; }
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }
        public string PcccUnitId { set; get; } // Đơn vị chữa cháy

        [JsonPropertyName("DieuDongDonViHoTroId")]
        public string SupportUnitIdToAdd { set; get; }

        [JsonPropertyName("BoDieuDongDonViHoTroId")]
        public string SupportUnitIdToRemove { set; get; }

        [JsonPropertyName("DieuDongPhuongTienId")]
        public string FireTruckIdToAdd { set; get; }

        [JsonPropertyName("BoDieuDongPhuongTienId")]
        public string FireTruckIdToRemove { set; get; }
    }
}
