using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FirebaseSendNotificationDto
    {
        public string CustomerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
