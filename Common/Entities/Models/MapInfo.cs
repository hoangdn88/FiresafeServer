using Common.Entities.DataTransferObjects.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models
{
    public class MapInfo : Base
    {
        public string CityId { get; set; } // Mã thành phố
        public string CityName { get; set; } // Tên thành phố
        public string DistrictId { get; set; } // Mã Quận,Huyện
        public string DistrictName { get; set; } // Tên Quận,Huyện
        public List<Coords> Point { get; set; } 
    }
}
