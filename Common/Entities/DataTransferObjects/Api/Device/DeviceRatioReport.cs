using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceRatioReportDto
    {
        public List<DeviceRatioDto> ByCountry { get; set; }
        public List<DeviceRatioDto> ByCity { get; set; }
    }

    public class DeviceRatioDto
    {
        public string DeviceName { get; set; }
        public double Ratio { get; set; }
        public int Count { get; set; }
    }
}
