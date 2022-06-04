using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchRouteMap
    {

        public Coords From { get; set; }

        public Coords To { get; set; }
    }
}
