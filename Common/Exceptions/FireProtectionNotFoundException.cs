using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FireProtectionNotFoundException : NotFoundException
    {
        public FireProtectionNotFoundException(string id) : base($"The fire protection with the id {id} was not found.")
        {
        }
        public FireProtectionNotFoundException() : base($"The fire protection was not found.")
        {

        }
    }
}
