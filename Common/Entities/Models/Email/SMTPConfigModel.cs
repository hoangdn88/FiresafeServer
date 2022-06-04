using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Entities.Models
{
    public class SMTPConfigModel
    {
        public string ClientId { get; set; }
        public string TenanId { get; set; }
        public string SenderEmail { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string ClientSecret { get; set; }
        
    }
}
