using Common.Entities.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions.Construction
{
    public class ConstructionManagementNotFoundException : NotFoundException
    {
        public ConstructionManagementNotFoundException(string id) : base( MessageError.ErrorConstructionManagementNotFound + $" id = {id}")
        {
        }
        public ConstructionManagementNotFoundException() : base(MessageError.ErrorConstructionManagementNotFound)
        {

        }

    }
}
