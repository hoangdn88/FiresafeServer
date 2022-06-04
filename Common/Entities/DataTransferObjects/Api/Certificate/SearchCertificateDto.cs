using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchCertificateDto
    {
        public string Name { get; set; }
        public LocationInfoDto Location { get; set; }
        public string ConstructionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
