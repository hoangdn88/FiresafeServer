using System;

namespace Common.Entities.Models.Fact
{
    public class DeviceTypeInfo : Base
    {
        public string DeviceTypeCode { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
    }
}
