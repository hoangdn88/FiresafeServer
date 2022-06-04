using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models
{
    public class GeoBase : Base
    {
        public double? Longitude { set; get; }
        public double? Latitude { set; get; } 
        public LocationInfo Location { set; get; } 
        public string LocationDetail { set; get; } 

        // This field is used to search a location within radius,
        // need update each time Longitude and Latitude change                                             
        public Coordinate Coordinate { set; get; }

        public GeoBase() : base()
        {
            
        }

        public void UpdateCoordinate()
        {
            Coordinate = new Coordinate((Longitude.HasValue & Longitude.GetValueOrDefault() == 0) || (Longitude == null) ? 105.85224151611328 : Longitude.Value, (Latitude.HasValue & Latitude.GetValueOrDefault() == 0) || (Latitude == null) ? 21.028676986694336 : Latitude.Value);
        }
    }

    public class Coordinate
    {
        public string type { set; get; }
        public double[] coordinates { set; get; }

        public Coordinate()
        {
            type = String.Empty;
            coordinates = new double[0];
        }

        public Coordinate(double longitude, double latitude)
        {
            type = "Point";

            coordinates = new double[2]
            {
                longitude,
                latitude
            };
        }
    }
}
