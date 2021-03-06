using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Notice
{
    public class CreateNoticeDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public NoticeType? Type { get; set; } // Loại thông báo
        public DeviceErrorType? DeviceErrorType { get; set; } // Loại thông báo
        public string ObjectId { get; set; }
        public DateTime? SendDate { get; set; }
        public string UserReceive { get; set; }
        public bool? ReadAlready { get; set; }
        public string UsernameSend { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
