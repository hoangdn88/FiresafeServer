using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FireFighterManagerExitException : ExitsException
    {
        public FireFighterManagerExitException() : base($"PC07 chỉ có 1 trưởng phòng.")
        {
        }
    }
}
