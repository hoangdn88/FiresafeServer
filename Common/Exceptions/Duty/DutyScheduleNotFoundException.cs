using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class DutyScheduleNotFoundException : NotFoundException
    {
        public DutyScheduleNotFoundException(string id) : base($"The schedule with the id {id} was not found.")
        {
        }
        public DutyScheduleNotFoundException() : base($"The schedule was not found.")
        {

        }
    }
}
