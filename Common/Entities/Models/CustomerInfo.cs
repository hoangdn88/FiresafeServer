using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class CustomerInfo : GeoBase
    {
        public string Name { get; set; }
        public string ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Info { get; set; }
        public string PhoneNumber { get; set; }
        public List<LocationInfo> Locations { set; get; }
        public CustomerInfo() : base()
        {
            UpdateCoordinate();
            CreatedDate = DateTime.Now;
        }
    }
}
