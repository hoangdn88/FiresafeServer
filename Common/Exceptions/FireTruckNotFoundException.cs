using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FireTruckNotFoundException : NotFoundException
    {
        public FireTruckNotFoundException(string id) : base($"The vehicle with the id {id} was not found.")
        {
        }
        public FireTruckNotFoundException() : base($"The vehicle was not found.")
        {

        }
    }
}
