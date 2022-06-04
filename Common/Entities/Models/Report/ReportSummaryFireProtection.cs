using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ReportSummaryFireProtection
    {
        public int? Category { get; set; }
        public int? RescueCount { get; set; }
        public int? IntendedCount { get; set; } // số lỗi cố ý
        public int? UnIntendedCount { get; set; } // số lỗi vô ý
        public int? OtherUnIntendedCount  { get; set; } // số lỗi khách quan khác
        public int? TerrorCount { get; set; }  // nghi khủng bố
        public int? DeadCount { get; set; } // số người chết
        public int? InjuredCount { get; set; } // số người bị thương
        public int? AssetDamage { get; set; } // thiệt hại tài sản
        public double? Rate { get; set; } // tỷ lệ
    }
}
