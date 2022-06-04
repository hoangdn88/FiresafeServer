using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models.Device
{
    public class DeviceHardwareInfo
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
        public BatteryStatus? BatteryStatus { set; get; } // trạng thái pin
        public int? NumOfSensorConnected { set; get; } // Số cảm biến kết nối tới, do server tự tính được
        public Dictionary<string, object> Configs { set; get; } // Cấu hình trong thiết bị
        public Dictionary<string, SensorInfo> Sensors { set; get; } // Danh sách các cảm biến
        public DateTime LastUpdateTime { set; get; } // Thời gian nhận dữ liệu lần cuối
        public string RestoreMeshCommand { set; get; }
        public string ConstructionId { set; get; }
        public string HardwareVersion { set; get; }
        public DateTime DeviceTime { set; get; }
        public string NetworkInterface { get; set; }
        public string TopicHeader { get; set; } // Header của topic
        public string MqttAddress { get; set; } // Địa chỉ MQTT
        public string MqttUserName { get; set; } // Tên đăng nhập MQTT
        public string MqttPassword { get; set; } // Mật khẩu MQTT
        public int ChargingInterval { get; set; } // Tần suất gửi dữ liệu khi cắm sạc
        public int UnchargeInterval { get; set; } // Tần suất gửi dữ liệu khi không cắm sạc
        public string UserPhoneNumber1 { get; set; } // Số điện thoại người dùng 1
        public string UserPhoneNumber2 { get; set; } // Số điện thoại người dùng 2
        public string UserPhoneNumber3 { get; set; } // Số điện thoại người dùng 3
        public bool BuzzerEnable { get; set; } // Cho phép còi kêu hay không
        public bool SyncAlarm { get; set; } // Cho phép đồng bộ các cảnh báo hay không
        public string NetworkAddress { get; set; } // Địa chỉ mạng MESH
        public int SmokeSensorWakeupInterval { get; set; } // Tần suất lấy mẫu cảm biến khói (s)
        public int SmokeSensorHeartbeatInterval { get; set; } // Tần suất gửi tin cảm biến khói (s)
        public int SmokeSensorThresHole { get; set; } // Ngưỡng lấy mẫu cảm biến khói
        public int TempSensorWakeupInterval { get; set; } // Tần suất lấy mẫu cảm biến nhiệt độ
        public int TempSensorHeartbeatInterval { get; set; } // Tần suất gửi tin cảm biến nhiệt độ
    }
}
