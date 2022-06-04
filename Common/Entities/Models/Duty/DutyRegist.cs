using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class DutyRegist : Base
    {
        public string Register { get; set; }// Người đăng ký trực
        public DateTime? FromDate { set; get; } // Thời gian bắt đầu
        public DateTime? ToDate { set; get; } // Thời gian kết thúc
        public string Status { set; get; } // Trạng thái
        public DutyType? Type { set; get; } // Loại trực
        public DateTime? CreateDate { set; get; } // Thời gian đăng ký
        public DateTime? UpdateDate { set; get; } // Thời gian đổi lịch trực
        public string DutyChanger { get; set; }// Người đổi lịch trực
        public string Note { set; get; } // Thông tin lý do đổi ca trực
        public DutyRegist() : base()
        {
        }
    }
}
