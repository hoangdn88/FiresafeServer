using System;
using System.Collections.Generic;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UserLoginDto
    {

        public string FullName { get; set; } // tên 
        public string UserName { get; set; } // tên đăng nhập
        public string Info { get; set; } // Thông tin đăng nhập
        public DateTime LoginTime { get; set; } // Thời gian đăng nhập

    }
}