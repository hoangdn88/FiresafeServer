using Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects
{
    public class MessageQueueDto
    {
        public MessageQueueDataType DataType { get; set; }
        public object Message { get; set; }
    }
    public enum MessageQueueDataType
    {
        DEVICE_FIRE_ALERT_EVENT = 0, // Cảnh báo cháy từ thiết bị
        DEVICE_HEART_BEAT = 1,
        SEND_DATA_TO_DEVICE = 2,
        FIRE_END_ALERT_EVENT = 3,
        USER_FIRE_ALERT_EVENT = 4, // Cảnh báo cháy từ người dân
        SEND_LINK_UPDATE_TO_DEVICE = 5 
    }

    public enum FireProcessStatus
    {
        DANG_XU_LY = 0,
        DANG_CHAY = 1,
        KET_THUC_XU_LY = 2, // Đã kết thúc vụ cháy
        CANH_BAO_SAI = 3, // Cán bộ trực xác nhận
        CANH_BAO_GIA = 4, // Thiết bị tự kết thúc cảnh báo
        DANG_CHO_XAC_MINH = 5 // Kiểm tra báo cháy 
    }
    public class DeviceMessageType
    {
        public const string HEART_BEAT = "heartbeat";
        public const string CONFIGURE_DEVICE = "config";
        public const string UPDATE = "update";
        public const string FIRE_EVENT = "fire";
        public const string SENSOR_INFO = "sensor";
        public const string DEVICE_INFO = "info";
    }

    public class FireSafeHeatBeatDto
    {
        public int FireStatus { get; set; }
        public int Csq { get; set; }
        public int ConnectedSensor { get; set; }
        public int Battery { get; set; }
        public int Vin { get; set; }
        public long UpdateTime { get; set; }
        public string NetworkInterface { get; set; }
        public int InTestMode { get; set; }
    }
    public class SensorInfoDto
    {
        public string SerialNumber { get; set; }
        public string Id { get; set; }
        public string Mac { set; get; }
        public string Firmware { set; get; }
        public WorkingStatus? Status { set; get; }
        public int? Battery { set; get; }
        public int? Temperature { set; get; }
        public int? Smoke { set; get; }
        public DateTime? UpdateTime { set; get; }
        //public string ConstructionId { set; get; }
        public string PairingDevice { set; get; }
        public string InstallLocation { set; get; }
        public string Info { set; get; }
        public SensorType? Type { set; get; }
        public DateTime? InstalledTime { set; get; }
        public DateTime? ExpiredTime { set; get; }
        public DateTime? CreateTime { set; get; }
    }
    public class DeviceHardwareInfoDto
    {
        public string Imei { set; get; }
        public string SimImei { set; get; }
        public string Firmware { set; get; }
        public string LoginReason { set; get; }
        public string HardwareVersion { set; get; }
        public long UpdateTime { set; get; }
    }
}
