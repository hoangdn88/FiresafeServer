using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class SearchReport
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string DeviceTypeCode { get; set; }
        public string ErrorCode { get; set; }
        public string IMEI { get; set; }
    }
}
