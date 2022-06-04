using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceInfoSearchDto
    {
        public string Imei { set; get; } 
        public string Name { set; get; }
        public List<string> ConstructionIds { set; get; }
        public DateTime? CreateFromTime { set; get; } 
        public DateTime? CreateToTime { set; get; } 
        public DateTime? ActiveFromTime { set; get; }
        public DateTime? ActiveToTime { set; get; }
        public DateTime? ExpiredFromTime { set; get; }
        public DateTime? ExpiredToTime { set; get; }
        public LocationInfoDto Location { set; get; }
        public string KeySearch { set; get; }
        public bool? ActiveStatus { set; get; }
        public bool? IsActive { set; get; }

    }
}
