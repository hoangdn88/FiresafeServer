using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public abstract class ExitsException : Exception
    {
        protected ExitsException(string message) : base(message)
        {
        }
    }
}
