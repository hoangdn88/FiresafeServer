﻿using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class CreateDeviceHistoryDto
    {
        [Required(ErrorMessage = "IMEI không được để trống")]
        public string Imei { set; get; } // IMEI thiết bị
        public string MacAddress { set; get; } // Địa chỉ mac của thiết bị
        public string SimImei { set; get; } // IMEI SIM lắp trong thiết bị
        public string Firmware { set; get; } // Phiên bản firmware
        public List<AlertType> AlertState { set; get; } // Trạng thái cảnh báo
        public int? BatteryPercent { set; get; } // % pin
        public DateTime? CreateTime { set; get; } // Thời điểm tạo thông tin lịch sử
        public DeviceStatus? Status { set; get; } // Trạng thái thiết bị on/off
        public string ConstructionId { set; get; }
        public BatteryStatus? BatteryStatus { set; get; } // trạng thái pin
        public int? InTestMode { set; get; } // Chế độ test
    }
}
