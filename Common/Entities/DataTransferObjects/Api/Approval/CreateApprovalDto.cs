using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateApprovalDto
    {
        public LocationInfoDto Location { get; set; }
        [Required(ErrorMessage = "Công trình không được để trống")]
        public string ConstructionId { get; set; }
        public DateTime? Date { get; set; } // ngày cấp
        public string Name { get; set; } // tên văn bản
        public string DocumentNumber { get; set; } // Số văn bản
        public string OrganName { get; set; } // Tên cơ quan cấp
        public string Note { get; set; } // Ghi chú
        //public string FileUrl { get; set; } // Đường dẫn file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
        public SolvingStatus? SolvingStatus { set; get; } // tình trạng xử lý
    }
}
