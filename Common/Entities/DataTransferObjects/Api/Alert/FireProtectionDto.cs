using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FireProtectionDto
    {
        public string Id { set; get; } // Mã địa điểm chữa cháy
        public string DeviceName { set; get; }
        public string FiringSource { set; get; } // Nguồn gây cháy
        public ExplosionType? ExplosionType { set; get; } // Loại cháy nổ
        public Area? Area { set; get; } // Khu vực
        public ConstructionDto Construction { set; get; } // Cơ sở công trình
        public PcccUnitDto PcccUnit { set; get; } // Đơn vị chữa cháy
        public DateTime? FireAlarmTime { set; get; } // Thời gian báo cháy
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public FireReason? Reason { set; get; } // Nguyên nhân cháy
        public int? InjuredCount { set; get; } // Số người bị thương
        public int? DeadCount { set; get; } // Số người chết
        public float? EstimateMoney { set; get; } // Số tiền ước tính thiệt hại
        public int? FiremanCount { set; get; } // Số CBCS tham gia chữa cháy
        public string Name { get; set; }
        public string PhoneNumber { set; get; } // Số điện thoại
        public string ReporterName { set; get; } // người báo
        public LocationInfoDto Location { set; get; }
        public string LocationDetail { set; get; }
        public string Note { set; get; } // Ghi chú
        public FireProcessStatus? ProcessStatus { set; get; }
        public List<FireProcessLog> ProcessLogs { set; get; } // Log các hành động của người dùng
        public List<SupportUnitFireProtectionDto> SupportUnits { set; get; }
        public List<WaterPointDto> WaterPoints { set; get; }
        public List<FireTruckFireProtectionDto> FireTrucks { set; get;}
        public List<SupportUnitDto> NearSupportUnits { set; get; }
        public List<WaterPointDto> NearWaterPoints { set; get; }
        public List<FireTruckDto> NearFireTrucks { set; get; }
        public List<AlertType> AlertType { set; get; } // nguồn báo cháy
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }
        public int? SupportUnitCount { set; get; } // Số đơn vị hỗ trợ
        public int? FireTruckCount { set; get; } // Số phương tiện điều động
    }

    public class SupportUnitFireProtectionDto : SupportUnitDto
    {
        public bool IsDieuDong { set; get; }
    }

    public class FireTruckFireProtectionDto : FireTruckDto
    {
        public bool IsDieuDong { set; get; }
    }
}
