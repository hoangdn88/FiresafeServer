using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class PropagateNotFoundException : NotFoundException
    {
        public PropagateNotFoundException(string id) : base($"The Propagate with the id {id} was not found.")
        {

        }
        public PropagateNotFoundException() : base($"The Propagate was not found.")
        {

        }
    }
}
