using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ConstructionCheckingPlanNotFoundException : NotFoundException
    {
        public ConstructionCheckingPlanNotFoundException(string id) : base($"The Plan Check Construction with the id {id} was not found.")
        {

        }
        public ConstructionCheckingPlanNotFoundException() : base($"The Plan Check Construction was not found.")
        {

        }
    }
}
