using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchByForPcccUnitScreen
    {
        public LocationInfoDto Location { get; set; }
        public string PcccUnitId { get; set; }
        public string Name { get; set; }
        public List<string> LstId { get; set; }
        public UnderType? UnderType { get; set; }
    }
}
