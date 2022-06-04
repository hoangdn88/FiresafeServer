using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Map
{
    public class MapDto 
    {
        public string Id { get; set; }
        public string CityId { get; set; } // Mã thành phố
        public string CityName { get; set; } // Tên thành phố
        public string DistrictId { get; set; } // Mã Quận,Huyện
        public string DistrictName { get; set; } // Tên Quận,Huyện
    }
}
