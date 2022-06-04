using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ApprovalInfo : Base
    {
        public LocationInfo Location { get; set; }
        public string ConstructionId { get; set; }
        public DateTime? Date { get; set; } // ngày cấp
        public string Name { get; set; } // tên văn bản
        public string DocumentNumber { get; set; } // Số văn bản
        public string OrganName { get; set; } // Tên cơ quan cấp
        public string Note { get; set; } // Ghi chú
        //public string FileUrl { get; set; } // Đường dẫn file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
        public SolvingStatus? SolvingStatus { set; get; }
        public ApprovalInfo() : base()
        {
        }
    }
}
