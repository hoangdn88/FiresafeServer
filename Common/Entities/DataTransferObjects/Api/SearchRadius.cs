using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchRadius
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Radius { get; set; }
    }
}
