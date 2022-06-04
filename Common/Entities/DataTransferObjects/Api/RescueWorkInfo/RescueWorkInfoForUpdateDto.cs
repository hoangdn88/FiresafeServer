using Common.Attributes;
using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class RescueWorkInfoForUpdateDto : UpdateBase
    {
        public string Name { get; set; } // Tên công tác chcn
        public string ReporterName { get; set; } // Tên người báo
        public string PhoneNumberReporter { get; set; } // SĐT người báo
        public DateTime? ReportDate { get; set; } // Ngày báo

        public LocationInfoDto Location { get; set; } // Mã tỉnh thành, quận huyện
        public double? Longitude { set; get; } // Kinh độ
        public double? Latitude { set; get; } // Vĩ độ
        public string LocationDetail { set; get; } // Địa chỉ cụ thể
        public Area? LocationType { set; get; } // Khu vực
        public string RescueWorkLocation { set; get; } // Nơi xảy ra vụ việc
        [PositiveNumber(ErrorMessage = "Khoảng cách với đội PCCC gần nhất phải >= 0")]
        public int? Distance { set; get; } // Khoảng cách với đội PCCC gần nhất
        public DateTime? StartTime { set; get; } // Thời gian bắt đầu xử lý
        public DateTime? EndTime { set; get; } // Thời gian kết thúc xử lý
        public string Reason { set; get; } // Nguyên nhân
        [PositiveNumber(ErrorMessage = "Số người được cứu phải >= 0")]
        public int? SavedCount { set; get; } // Số người được cứu
        [PositiveNumber(ErrorMessage = "Số người chết phải >= 0")]
        public int? DeadCount { set; get; } // Số người chết
        [PositiveNumber(ErrorMessage = "Số người tự thoát phải >= 0")]
        public int? SelfEscapeCount { set; get; } // Số người tự thoát
        [PositiveNumber(ErrorMessage = "Số tiền thiệt hại phải >= 0")]
        public double? MoneyLoss { set; get; } // Số tiền thiệt hại
        public string OtherDamage { set; get; } // Thiệt hại khác
        [PositiveNumber(ErrorMessage = "số CBCS tham gia phải >= 0")]
        public int? CBCSCount { set; get; } // số CBCS tham gia
        public string Summary { set; get; } // Tóm tắt vụ việc

        public string MonthOfYear { set; get; }
        public int? Count { set; get; }
    }
}
