using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models.Fact
{
    public class JigTestResult : Base
    {
        public JigTestResult() : base()
        {
        }
        public int Timestamp { get; set; }
        public DateTime DateTest { get; set; }
        public string DeviceType { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwardVersion { get; set; }
        public string MacJIG { get; set; }
        public string GsmIMEI { get; set; }
        public string ErrorCode { get; set; }
        public object TestResult { get; set; }
        //public Dictionary<string, object> ErrorResults { get; set; }
    }
}
