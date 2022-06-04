using System;

namespace Common.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {
        }
    }
}
