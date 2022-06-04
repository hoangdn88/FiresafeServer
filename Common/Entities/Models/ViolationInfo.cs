using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ViolationInfo : Base
    {
        public LocationInfo Location { set; get; } 
        public string ConstructionId { set; get; }
        public string ViolatorName { set; get; } // tên người vi phạm
        public DateTime? Date { set; get; } // Thời gian xử lý
        public string Content { set; get; } // Nội dung hành vi 
        //public List<string> FileUrl { set; get; } // Đường dẫn đến file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
        public bool? Warnning { set; get; } // Cảnh cáo
        public List<SuspensionType> SuspensionType { set; get; } // 0:Tạm đình chỉ, 1: Đình chỉ, 2: Không
        public DateTime? SuspensionDate { set; get; } // Ngày đình chỉ
        public DateTime? RecoverDate { set; get; } // Ngày phục hồi
        public List<BehaviourGroup> Behaviour { set; get; } // Nhóm hành vi
        public double? Fines { set; get; } // Số tiền phạt
        public string HandlingMeasures { set; get; } // Biện pháp xử lý khác
        public SolvingStatus? SolvingStatus { set; get; }
        public ViolationInfo() : base()
        {
        }
    }
}
