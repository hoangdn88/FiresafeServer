using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class PropagateInfo : Base
    {
        public LocationInfo Location { get; set; } // Vị trí 
        public string ConstructionId { get; set; } // Cơ sở công trình
        public DateTime? Time { get; set; } // Thời gian
        public string CertificateNum { get; set; } // Số giấy chứng nhận
        public int? TotalHour { get; set; } // Số giờ
        public string Content { get; set; } // Nội dung huấn luyện
        public int? PcccCount { get; set; } // Số lực lượng pccc tham gia
        public int? ManangerCount { get; set; } // Số lãnh đạo tham gia
        public int? WorkerCount { get; set; } // Số người lao động tham gia
        public int? OtherCount { get; set; } // Số người Khác
        public PropagateInfo() : base()
        {
        }
    }
}
