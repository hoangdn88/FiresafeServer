using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchPcccUnitDto
    {
        public string Name { set; get; }
        public LocationInfoDto Location { set; get; }
        public UnderType? UnderType { get; set; }
        public string Code { set; get; }
        public List<LocationInfoDto> LocationList { set; get; }
    }
}
