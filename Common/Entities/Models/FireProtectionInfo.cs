using Common.Entities.DataTransferObjects;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.Models
{
    public class FireProtectionInfo : Base
    {
        public string FiringSource { set; get; } // Nguồn gây cháy
        public string Name { get; set; }
        public string PhoneNumber { set; get; } // Số điện thoại
        public LocationInfo Location { set; get; }
        public string LocationDetail { set; get; }
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }
        public ExplosionType? ExplosionType { set; get; } // Loại cháy nổ
        public Area? Area { set; get; } // Khu vực
        public string ConstructionId { set; get; } // Cơ sở công trình
        public string PcccUnitId { set; get; } // Đơn vị chữa cháy
        public DateTime? FireAlarmTime { set; get; } // Thời gian báo cháy
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public FireReason? Reason { set; get; } // Nguyên nhân cháy
        public int? InjuredCount { set; get; } // Số người bị thương
        public int? DeadCount { set; get; } // Số người chết
        public int? EstimateMoney { set; get; } // Số tiền ước tính thiệt hại
        public int? FiremanCount { set; get; } // Số CBCS tham gia chữa cháy
        public string Note { set; get; } // Ghi chú
        public string ReporterName { set; get; } // Tên người báo
        public FireProcessStatus? ProcessStatus { set; get; }
        public List<FireProcessLog> ProcessLogs { set; get; } // Log các hành động của người dùng
        public List<string> SupportUnitIds;
        public List<string> WaterPointIds { set; get; }
        public List<string> FireTruckIds { set; get; }
        public List<string> DanhSachDieuDongIds { set; get; }
        public string DeviceName { set; get; }
        public List<AlertType> AlertType { set; get; } // nguồn báo cháy
        public FireProtectionInfo() : base()
        {
        }
    }

    public class FireProcessLog
    {
        public DateTime Time { set; get; }
        public string Info { set; get; }
    }
}
