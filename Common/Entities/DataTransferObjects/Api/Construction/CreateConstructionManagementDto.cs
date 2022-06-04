using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Construction
{
    public class CreateConstructionManagementDto
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string ConstructionId { get; set; }
    }
}
