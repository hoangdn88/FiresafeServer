using Common.Entities.DataTransferObjects.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models
{
    public class GeoLocationInfo
    {
        public string Level1_id { get; set; } // Mã thành phố
        public string Name { get; set; } // Tên thành phố
        public double[][][][] Coordinates { get; set; } // Danh sách tọa độ
        public List<GeoLocationDistrict> Level2s { get; set; }
    }

    public class GeoLocationDistrict
    {
        public string Level2_id { get; set; } // Mã quận huyện
        public string Name { get; set; } // Tên quận huyện
        public double[][][][] Coordinates { get; set; } // Danh sách tọa độ
    }


}
