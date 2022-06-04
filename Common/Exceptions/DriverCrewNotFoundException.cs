using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class DriverCrewNotFoundException : NotFoundException
    {
        public DriverCrewNotFoundException(string id) : base($"The Driver Crew with the id {id} was not found.")
        {
        }
        public DriverCrewNotFoundException() : base($"The Driver Crew was not found.")
        {

        }
    }
}
