using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class PlanningInfoNotFoundException : NotFoundException
    {
        public PlanningInfoNotFoundException(string id) : base($"The plan with the id {id} was not found.")
        {

        }
        public PlanningInfoNotFoundException() : base($"The plan was not found.")
        {

        }
    }
}
