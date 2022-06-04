using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ReportFireProcessingStatusInfo
    {
        public int? StatusName { get; set; }
        public int? Count { get; set; }
        public double? Ratio { get; set; }
    }
}
