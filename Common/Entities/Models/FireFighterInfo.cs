using Common.Entities.Enum;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.Models
{
    public class FireFighterInfo : Base
    {        
        public string Code { get; set; } // Mã số cán bộ ngành
        public string Name { get; set; } // Họ Tên 
        public DateTime? Birthday { get; set; } // Ngày sinh
        public string Email { get; set; }  
        public string Function { get; set; } // Chức năng công việc
        public LocationInfo Location { get; set; } 
        public PositionType? Position { get; set; } // Chức vụ       
        public RankType? Rank { get; set; } // Cấp bậc        
        public UnderType? Under { get; set; } // Trực thuộc đơn vị
        public string PcccUnitId { get; set; } // Trực thuộc đơn vị
        public string PhoneNumber { get; set; } 
        public string Passport { get; set; } // Mã cmtnd
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartOfWorkDate { get; set; }

        public FireFighterInfo() : base()
        {

        }
    }
 
}
