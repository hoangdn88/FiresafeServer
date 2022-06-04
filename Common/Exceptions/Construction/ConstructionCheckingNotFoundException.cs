using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ConstructionCheckingNotFoundException : NotFoundException
    {
        public ConstructionCheckingNotFoundException(string id) : base($"The Check Construction with the id {id} was not found.")
        {
        }
        public ConstructionCheckingNotFoundException() : base($"The Check Construction was not found.")
        {

        }
    }
}
