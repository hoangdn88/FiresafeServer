using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class GeoBaseDto
    {
        public double? Longitude { set; get; }
        public double? Latitude { set; get; }
        public LocationInfoDto Location { set; get; }
        public string LocationDetail { set; get; }

        public GeoBaseDto() : base()
        {

        }

    }

}
