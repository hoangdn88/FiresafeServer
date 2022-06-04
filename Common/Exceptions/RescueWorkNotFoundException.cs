using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class RescueWorkNotFoundException : NotFoundException
    {
        public RescueWorkNotFoundException(string id) : base($"The rescue work with the id {id} was not found.")
        {

        }
        public RescueWorkNotFoundException() : base($"The rescue work was not found.")
        {

        }
    }
}
