using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ApprovalNotFoundException : NotFoundException
    {
        public ApprovalNotFoundException(string id) : base($"The Approval with the id {id} was not found.")
        {
        }
        public ApprovalNotFoundException() : base($"The Approval was not found.")
        {

        }
    }
}
