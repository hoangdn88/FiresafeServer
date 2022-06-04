using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class LocationInfo
    {
        public string CityId { get; set; } // Tên thành phố
        public string DistrictId { get; set; } // Tên huyện
        public string WardId { get; set; } // Tên xã, phường
    }
}
