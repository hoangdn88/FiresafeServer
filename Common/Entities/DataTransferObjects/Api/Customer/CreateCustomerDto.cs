using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateCustomerDto : GeoBaseDto
    {
        public string Name { get; set; }

        public string ParentId { get; set; }

        public string Address { get; set; }

        public string TaxCode { get; set; }

        public string Info { get; set; }

        public string PhoneNumber { get; set; }

        public List<LocationInfoDto> Locations { set; get; }
    }
}
