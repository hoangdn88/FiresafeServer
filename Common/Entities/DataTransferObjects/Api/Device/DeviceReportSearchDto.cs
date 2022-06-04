using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceReportSearchDto
    {
        public string CityId { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }
}
