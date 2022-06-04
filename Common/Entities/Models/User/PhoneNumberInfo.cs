using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class PhoneNumberInfo
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Info { get; set; }
        public PhoneNumberType? PhoneNumberType { get; set; } 
    }
}
