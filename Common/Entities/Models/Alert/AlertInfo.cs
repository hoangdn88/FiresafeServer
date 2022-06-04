using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class AlertInfo
    {
        public long Id { get; set; }
        public string DeviceImei { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public AlertType Type { set; get; }
    }

    public enum AlertType
    {
        CenterButton = 0, // Cảnh báo từ nút bấm trung tâm
        RemoteControl, // Cảnh báo từ điều khiển từ xa
        SmokeSensor, // Cảnh báo từ cảm biến khói
        DoorSensor, // Cảnh báo từ cảm biến cửa
        PirSensor, // Cảnh báo từ cảm biến PIR
        TemperatureSensor, // Cảnh báo từ cảm biến nhiệt độ
        DeviceIo, // Cảnh báo từ I/O (đấu với tủ báo cháy)
        Dtmf, // Cảnh báo từ tín hiệu DTMF
        FireBoxError, // Cảnh báo tủ báo cháy có lỗi.
        LostMainPower, // Cảnh báo mất nguồn chính
        LostSubPower, // Cảnh báo mất nguồn dự phòng
        FireRaySensor, // Cảnh báo từ cảm biến tia lửa
        LightBellDevice, // Cảnh báo từ bộ chuông đèn, nút bấm
        SmokeAndTempSensor, // Cảnh báo từ cảm biến khói+nhiệt
        UserAlert, // Cảnh báo do người dân gọi điện

    }
}
