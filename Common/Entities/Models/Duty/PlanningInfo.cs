﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class PlanningInfo : Base
    {
        public LocationInfo Location { get; set; } // Mã tỉnh thành
        public DateTime? SetUpDate { get; set; } // Ngày lập phương án
        public DateTime? PracticeDate { get; set; } // Ngày thực hiện phương án
        public string ConstructionId { get; set; } // Cơ sở công trình
        public string PracticeSituation { get; set; } // Tình huống thực tập
        public string BrowserLevel { get; set; } // Cấp phê duyệt
        public string FirePoint { get; set; } // Điểm cháy
        public string Comment { get; set; } // Ý kiến nhận xét, đánh giá
        public List<string> PcccUnits { get; set; } // Đơn vị tham gia
        public List<string> Users { get; set; } // Cán bộ chiến sĩ tham gia
        public List<string> FireTrucks { get; set; } // Phương tiện tham gia
        public string MonthOfYear { get; set; }
        public int? Count { get; set; }
        public PlanningInfo() : base()
        {
        }
    }
}
