using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ViolationNotFoundException : NotFoundException
    {
        public ViolationNotFoundException(string id) : base($"The Violation with the id {id} was not found.")
        {

        }
        public ViolationNotFoundException() : base($"The Violation was not found.")
        {

        }
    }
}
