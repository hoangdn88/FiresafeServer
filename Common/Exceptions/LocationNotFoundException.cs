using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(string id) : base($"The location with the id {id} was not found.")
        {
        }
        public LocationNotFoundException() : base($"The location was not found.")
        {

        }
    }
}
