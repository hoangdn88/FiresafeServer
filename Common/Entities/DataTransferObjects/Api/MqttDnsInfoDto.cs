using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class MqttDnsInfoDto
    {
        public string ServerIp { get; set; }
        public string MqttPort { get; set; }
        public string MqttUserName { get; set; }
        public string MqttPassWord { get; set; }
    }
}
