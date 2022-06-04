using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceReportDto
    {
        public ConstructionDto Construction { set; get; }
        public int? DeviceSum { set; get; } // Tổng số thiết bị
        public int? DeviceCount { set; get; } // Số thiết bị trung tâm
        public int? BellCount { set; get; } // Số thiết bị chuông đèn
        public int? SmokeSensorCount { set; get; } // Số cảm biến khói
        public int? TemperatureSensorCount { set; get; } // Số cảm biến nhiệt
        public int? TemperatureSmokeSensorCount { set; get; } // Số cảm biến khói nhiệt
        public int? OrtherSensorCount { set; get; } // Số cảm biến khác

        public double? DevicePercent { set; get; } // Phần trăm thiết bị trung tâm
        public double? BellPercent { set; get; } // Phần trăm thiết bị chuông đèn
        public double? SmokeSensorPercent { set; get; } // Phần trăm cảm biến khói
        public double? TemperatureSensorPercent { set; get; } // Phần trăm cảm biến nhiệt
        public double? TemperatureSmokeSensorPercent { set; get; } // Phần trăm cảm biến khói nhiệt
        public double? OrtherSensorPercent { set; get; } // Phần trăm cảm biến khác
    }
}
