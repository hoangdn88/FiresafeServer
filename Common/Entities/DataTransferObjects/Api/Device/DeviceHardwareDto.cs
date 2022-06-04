using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceHardwareDto
    {
        public string Imei { set; get; } // IMEI thiết bị
        public string SimImei { set; get; } // IMEI SIM lắp trong thiết bị
        public string NetworkKey { set; get; } // Key của mạng MESH
        public string AppKey { set; get; } // Key của ứng dụng
        public int TotalNode { set; get; } // Tổng số node (lưu trong thiết bị)
        public string MacAddress { set; get; } // Địa chỉ mac của thiết bị
        public string Firmware { set; get; } // Phiên bản firmware
        public List<AlertType> AlertState { set; get; } // Trạng thái cảnh báo
        public int Csq { set; get; } // Cường độ sóng
        public int Vin { set; get; } // Điện áp vào
        public int BatteryPercent { set; get; } // % pin
        public int? NumOfSensorConnected { set; get; } // Số cảm biến kết nối tới, do server tự tính được
        public Dictionary<string, object> Configs { set; get; } // Cấu hình trong thiết bị
        public DateTime LastUpdateTime { set; get; } // Thời gian nhận dữ liệu lần cuối
        public string RestoreMeshCommand { set; get; }
        public string ConstructionId { set; get; }
        public string HardwareVersion { set; get; }
        public DateTime DeviceTime { set; get; }
        public string NetworkInterface { get; set; }
    }
}
