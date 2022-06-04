using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateUserActionDto
    {
        public string UserName { get; set; }
        public string Path { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; } // tham số truyền vào
        public DateTime? AuditTime { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; } // from webbrowser ex: chrome86
        public int? ObjectId { get; set; } // id của đối tượng (query/update/delete)
        public string NewObjectValue { get; set; } // giá trị API truyền vào
        public string ErrorMessage { get; set; } // 
        public string Response { get; set; } 
        public string Message { get; set; }
        

    }
}