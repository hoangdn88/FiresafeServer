using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchMapDto
    {
        public string CityId { get; set; } 
        public string DistrictId { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string LocationDetail { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public bool? SearchCity { get; set; }
        public List<string> CityIds { get; set; }
    }
}
