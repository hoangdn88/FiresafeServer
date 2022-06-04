using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class DutyScheduleInfo : Base
    {
        public DateTime? FromDate { set; get; } // thời gian bắt đầu
        public DateTime? ToDate { set; get; } // thời gian kết thúc
        public LocationInfo Location { set; get; } // Tỉnh thành, Quận huyện trực
        public string PcccUnitId { set; get; } // Đơn vị PCCC
        public string OnDutyDirection { set; get; } // Trực chỉ huy
        public string OnDutyUnitUser { set; get; } // Trực ban đơn vị
        public string OnDutyFireSafer { set; get; } // Trực giải quyết vụ cháy
        public string OnDutyInfo { set; get; } // Trực thông tin
        public List<string> FireTruckIds { set; get; } // Danh sách Tổ lái phương tiện chữa cháy
        public List<string> FireFighterIds { set; get; } // Danh sách CBCS không theo phương tiện
        public string Note { set; get; } // Tình hình trong ngày
        public string OnDutyLeader { set; get; } // Trực lãnh đạo
        public string OnDutyGeneralStaff { set; get; } // Cán bộ tổng hợp
        public int FireFighterSum { set; get; } // Tổng số CBCS
        public int FireFighterOnlCount { set; get; } // Tổng số CBCS có mặt
        public int FireFighterOffCount { set; get; } // Tổng số CBCS vắng mặt
        public int AdministrativeCount { set; get; } // Cán bộ hành chính
        public DutyScheduleInfo() : base()
        {
        }
    }
}
