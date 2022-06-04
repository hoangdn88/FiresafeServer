using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models.Fact
{
    public class DeviceInfo:Base
    {
        public string GsmIMEI { get; set; }
        public string DeviceType { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwardVersion { get; set; }
        public DateTime DateTest { get; set; }
        public string MacJIG { get; set; }
        public bool IsPass { get; set; }
        public List<JigTestResult> TestResults { get; set; }
    }
}
