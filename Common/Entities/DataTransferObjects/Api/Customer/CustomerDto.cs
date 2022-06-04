using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Customer
{
    public class CustomerDto : GeoBaseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ParentId { get; set; }

        public string Address { get; set; }

        public string TaxCode { get; set; }

        public string Info { get; set; }

        public string PhoneNumber { get; set; }

        public List<LocationInfo> Locations { set; get; }
    }
}
