using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class InstallReportDto
    {
        public ConstructionDto Construction { get; set; }
        public long DeviceCount { get; set; }
    }    
}
