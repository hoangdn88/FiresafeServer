using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class ResultConstructionCheckingInfo
    {
        public LocationInfo Location { get; set; }
        public int? CheckingCount { get; set; }
        public int? ViolationCount { get; set; }
        public int? WarningCount { get; set; }
        public double? FineCount { get; set; }
        public double? FineResult { get; set; }
        public int? TemporarySuspensionCount { get; set; }
        public int? SuspensionCount { get; set; }
        public int? TrainingCount { get; set; }
        public int? PeopleJoinTrainingCount { get; set; }
        public double? HourTrainingCount { get; set; }
        public int? CertificateCount { get; set; }
    }
}
