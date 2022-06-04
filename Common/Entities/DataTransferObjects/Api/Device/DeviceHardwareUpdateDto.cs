using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class DeviceHardwareUpdateDto
    {
        public string Imei { set; get; } // IMEI thiết bị        
        public string ConstructionId { set; get; }
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
