using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ConstructionCheckingPlanInfo : Base
    {
        public string Name { get; set; } // Tên kế hoạch
        public List<LocationInfo> Location { get; set; } // Vị trí kiếm tra
        public string Target { get; set; } // Mục tiêu nội dung kiểm tra
        public string RequireResult { get; set; } // Yêu cầu đầu ra
        public string Determination { get; set; } // Quyết định kiểm tra
        public List<string> Checkers { get; set; } // Người kiểm tra
        public DateTime? FromDate { get; set; } // Ngày bắt đầu
        public DateTime? ToDate { get; set; } // Ngày kết thúc
        public string Description { get; set; } // Mô tả
        public string FileUrl { get; set; } // Đường dẫn up file
        public ConstructionCheckingPlanInfo() : base()
        {
        }
    }
}
