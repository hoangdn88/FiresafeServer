using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class DataReportFireProtectionDto
    {
        public string FiringSource { set; get; } // Nguồn gây cháy
        public ExplosionType? ExplosionType { set; get; } // Loại cháy nổ
        public Area? Area { set; get; } // Khu vực
        public string ConstructionId { set; get; } // Cơ sở công trình
        public string PcccUnitId { set; get; } // Đơn vị chữa cháy
        public string LocationDetail { set; get; } // Địa chỉ chi tiết
        public string FireAlarmTime { set; get; } // Thời gian báo cháy
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public FireReason? Reason { set; get; } // Nguyên nhân cháy
        public int? InjuredCount { set; get; } // Số người bị thương
        public int? DeadCount { set; get; } // Số người chết
        public int? EstimateMoney { set; get; } // Số tiền ước tính thiệt hại
        public int? FiremanCount { set; get; } // Số CBCS tham gia chữa cháy
        public string Note { set; get; } // Ghi chú
        public FireProcessStatus? ProcessStatus { set; get; }

    }
}
