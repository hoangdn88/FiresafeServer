using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class DriverCrewInfo : Base
    {
        public List<string> FireFighterId { set; get; } // Cơ sở công trình
        public string FireTruckId { set; get; } // Cơ sở công trình
        public DriverCrewInfo() : base()
        {
        }
    }
}
