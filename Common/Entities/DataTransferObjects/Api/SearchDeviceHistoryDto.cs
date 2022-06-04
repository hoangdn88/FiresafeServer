using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchDeviceHistoryDto
    {
        public string Imei { set; get; } // IMEI thiết bị
        public AlertType? AlertState { set; get; } // Trạng thái cảnh báo
        public int? BatteryPercent { set; get; } // % pin
        public DateTime? FromDate { set; get; } 
        public DateTime? ToDate { set; get; }
        public DeviceStatus? Status { set; get; }
        public List<string> ConstructionIdList { set; get; }
    }
}
