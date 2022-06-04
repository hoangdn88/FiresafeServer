using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class AlertEndDto
    {
        public string Id { set; get; }
        public FireAlertEndSender Sender { get; set; }
        public string DeviceImei { get; set; }
        public FireProcessStatus ProcessStatus { get; set; }
    }

    public enum FireAlertEndSender
    {
        USER = 0,
        DEVICE = 1,
        SYSTEM = 2
    }
}
