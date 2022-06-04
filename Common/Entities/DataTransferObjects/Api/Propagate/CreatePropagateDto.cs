using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreatePropagateDto
    {
        public LocationInfoDto Location { get; set; } // Vị trí 
        [Required(ErrorMessage = "Công trình không được để trống")]
        public string ConstructionId { get; set; }
        public DateTime? Time { get; set; }
        public string CertificateNum { get; set; } // Số giấy chứng nhận
        public int? TotalHour { get; set; } // Số giờ
        public string Content { get; set; } // Nội dung huấn luyện
        public int? PcccCount { get; set; } // Số lực lượng pccc tham gia
        public int? ManangerCount { get; set; } // Số lãnh đạo tham gia
        public int? WorkerCount { get; set; } // Số người lao động tham gia
        public int? OtherCount { get; set; } // Số người Khác
    }
}
