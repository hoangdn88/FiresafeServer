using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.FireTruck
{
    public class FireTruckReportDto
    {
        public LocationInfo Location { get; set; }
        public string PcccUnitName { get; set; }
        public int? Xe3m3Count { get; set; }
        public int? Xe5m3Count { get; set; }
        public int? XeBomCount { get; set; }
        public int? XeBotCount { get; set; }
        public int? XeMayCount { get; set; }
        public int? XeThangCount { get; set; }
        public double? GoodPercent { get; set; }
        public double? BadPercent { get; set; }
        public double? NeedRepairPercent { get; set; }
        public double? NeedReplacePercent { get; set; }
        public List<FireTruckReportDto> Children { get; set; }
    }
}
