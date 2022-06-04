using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class StatisticDto
    {
        public int ConstructionCount { get; set; }
        public int PcccUnitCount { get; set; }
        public int AlertingCount { get; set; }
        public int AlertCount { get; set; }
        public int DeviceCount { get; set; }
        public int OnlineCount { get; set; }
        public int OfflineCount { get; set; }
        public int ConnectedCityCount { get; set; }
        public float TotalDamage { get; set; }
        public List<DataStatistic> Devices { get; set; }
        public List<DeviceStatistic> DevicesByCity { get; set; }
        public List<DataStatistic> Alerts { get; set; }
        public List<DataStatistic> Damages { get; set; }
    }

    public class DeviceStatistic
    {
        public string CityId { get; set; }
        public int Count { get; set; }
    }

    public class DataStatistic
    {
        public DateTime Time { get; set; }
        public double Value { get; set; }
    }
}
