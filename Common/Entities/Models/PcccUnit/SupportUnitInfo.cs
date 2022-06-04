using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class SupportUnitInfo : GeoBase
    {        
        public string Code { set; get; } // Mã đơn vị hỗ trợ
        public string Name { set; get; } // Tên vị hỗ trợ
        public string PhoneNumber { set; get; } // Số điện thoại đơn vị hỗ trợ
        public SupportUnitType? Type { set; get; } // Loại đơn vị hỗ trợ        
        public string PcccUnitId { get; set; } // Trực thuộc đơn vị
                                               
        public SupportUnitInfo() : base()
        {
        }
    }


}
