using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class RescueWorkInfo : GeoBase
    {
        public string Name { get; set; } // Tên công tác chcn
        public string ReporterName { get; set; } // Tên người báo
        public string PhoneNumberReporter { get; set; } // SĐT người báo
        public DateTime? ReportDate { get; set; } // Ngày báo
        public Area? LocationType { set; get; } // Khu vực
        public string RescueWorkLocation { set; get; } // Nơi xảy ra vụ việc
        public int? Distance { set; get; } // Khoảng cách với đội PCCC gần nhất
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public string Reason { set; get; } // Nguyên nhân
        public int? SavedCount { set; get; } // Số người được cứu
        public int? DeadCount { set; get; } // Số người chết
        public int? SelfEscapeCount { set; get; } // Số người tự thoát
        public double? MoneyLoss { set; get; } // Số tiền thiệt hại
        public string OtherDamage { set; get; } // Thiệt hại khác
        public int? CBCSCount { set; get; } // số CBCS tham gia
        public string Summary { set; get; } // Tóm tắt vụ việc

        public string MonthOfYear { set; get; }
        public int? Count { set; get; }
        public RescueWorkInfo() : base()
        {
        }
    }
}
