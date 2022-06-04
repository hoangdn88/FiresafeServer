using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ConstructionNotFoundException : NotFoundException
    {
        public ConstructionNotFoundException(string id) : base($"The construction with the id {id} was not found.")
        {
        }
        public ConstructionNotFoundException() : base($"The location was not found.")
        {

        }
    }
}
