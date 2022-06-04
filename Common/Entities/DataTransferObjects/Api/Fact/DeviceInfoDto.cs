using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class DeviceInfoDto
    {
        public string GsmIMEI { get; set; }
        public bool IsPass { get; set; }
        public string MacJIG { get; set; }
        public DateTime DateTest { get; set; }
        public string CountPass { get; set; }
        public List<ErrorDetailDto> ErrorDetails { get; set; }
    }

    public class ErrorDetailDto
    {
        public string ErrorCode { get; set; }
        public DateTime DateTest { get; set; }
        public bool TestResult { get; set; }
    }

    public class DeviceTypeResponseDto : UpdateBase
    {
        public string DeviceTypeCode { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
    }
}
