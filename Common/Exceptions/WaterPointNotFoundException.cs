using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class WaterPointNotFoundException : NotFoundException
    {
        public WaterPointNotFoundException(string id) : base($"The Water Point with the id {id} was not found.")
        {

        }
        public WaterPointNotFoundException() : base($"The Water Point was not found.")
        {

        }
    }
}
