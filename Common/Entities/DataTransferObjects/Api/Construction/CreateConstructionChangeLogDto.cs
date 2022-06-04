using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Construction
{
    public class CreateConstructionChangeLogDto
    {
        public DateTime? ChangeDate { set; get; } // Ngày thay đổi
        public string Content { set; get; } // Nội dung

        public string Url { set; get; } // Link file đính kèm
        public string CreateUser { set; get; } // id người tạo
        public string Status { set; get; } // trạng thái

        public string ApprovalUser { set; get; } // id người duyệt
        public string Action { set; get; } // hành động
        public string ConstructionId { set; get; }
    }
}
