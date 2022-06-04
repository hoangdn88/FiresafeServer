using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchWaterPointDto
    {
        public string Name { get; set; }
        public LocationInfoDto Location { get; set; }

    }
}
