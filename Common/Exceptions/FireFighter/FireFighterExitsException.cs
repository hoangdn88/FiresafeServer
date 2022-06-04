using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FireFighterExitsException : ExitsException
    {
        public FireFighterExitsException(string passport) : base($"Đã tồn tại nhân viên chữa cháy có CCCD/CMND {passport} trong hệ thống.")
        {
        }
    }
}
