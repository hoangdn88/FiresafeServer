using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class ReportErrorDetailGSM
    {
        public List<DeviceInfoDto> DeviceInfoDtos { get; set; }
        public List<DataDictionary> ChartErrorDetail { get; set; }
    }
}
