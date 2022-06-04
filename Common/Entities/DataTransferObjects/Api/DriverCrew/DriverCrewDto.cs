using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class DriverCrewDto
    {
        public string Id { get; set; }
        public List<string> FireFighterId { set; get; } 
        public string FireTruckId { set; get; }
    }
}
