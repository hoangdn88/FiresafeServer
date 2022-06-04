using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class SupportUnitNotFoundException : NotFoundException
    {
        public SupportUnitNotFoundException(string id) : base($"The Support Unit with the id {id} was not found.")
        {

        }
        public SupportUnitNotFoundException() : base($"The Support Unit was not found.")
        {

        }
    }
}
