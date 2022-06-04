namespace Common.Entities.Models
{
    using System;
    using System.Collections.Generic;

    public class UserLogin : Base
    {        
        public string FullName { get; set; } // tên 
        public string UserName { get; set; } // tên đăng nhập

        public string Info { get; set; } // Thông tin đăng nhập
    
        public DateTime? LoginTime { get; set; } // Thời gian đăng nhập

    }
}