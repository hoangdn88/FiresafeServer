using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchSupportUnitDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public LocationInfoDto Location { get; set; }
    }
}
