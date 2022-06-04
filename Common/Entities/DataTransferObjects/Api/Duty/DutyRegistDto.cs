using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class DutyRegistDto
    {
        public string Id { get; set; }// Mã đăng ký trực
        public string Register { get; set; }// Người đăng ký trực
        public DateTime? FromDate { set; get; } // Thời gian bắt đầu
        public DateTime? ToDate { set; get; } // Thời gian kết thúc
        public string Status { set; get; } // Trạng thái
        public DutyType? Type { set; get; } // Loại trực
        public string Note { set; get; } // Thông tin lý do đổi ca trực
    }
}
