using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ConstructionCheckingInfo : Base
    {
        public string Name { set; get; } // Tên phiếu kiểm tra
        public string Type { set; get; } // type kế hoạch kiểm tra
        public string ConstructionId { set; get; } // Công trình kiểm tra
        public DateTime? CheckDate { set; get; } // Ngày kiểm tra
        public EvaluateType? Evaluate { set; get; } // Đánh giá
        public string Content { set; get; } // Nội dung kiểm tra
        public string ContentDetail { set; get; } // Nội dung chi tiết
        public CheckStatus? CheckingStatus { set; get; } // Trạng thái thực hiện
        public string FileUrl { set; get; } // Đường dẫn file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
        public List<string> Checker { set; get; } // Cán bộ thực hiện
        public SolvingStatus? SolvingStatus { set; get; }
        public string ConstructionCheckingPlanId { set; get; } // Chi tiết kế hoạch kiểm tra
        public ConstructionCheckingInfo() : base()
        {
        }
    }
}
