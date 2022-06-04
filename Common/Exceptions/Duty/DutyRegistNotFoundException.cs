using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class DutyRegistNotFoundException : NotFoundException
    {
        public DutyRegistNotFoundException(string id) : base($"The duty with the id {id} was not found.")
        {
        }
        public DutyRegistNotFoundException() : base($"The duty was not found.")
        {

        }
    }
}
