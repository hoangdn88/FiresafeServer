using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class UpdateDeviceInfoDto : UpdateBase
    {
        [Required(ErrorMessage = "IMEI không được để trống")]
        public string Imei { set; get; } // IMEI thiết bị
        public string Name { set; get; }
        public string SeriNumber { set; get; }
        public string LoaiThietBi { set; get; }
        public bool? IsActive { set; get; }
        public string ConstructionId { set; get; }
        public DateTime? ActiveTime { set; get; } // Thời gian bắt đầu kích hoạt (dùng để tính thu phí)
        public DateTime? ExpiredTime { set; get; } // Thời điểm hết hạn
        public string OldImei { set; get; }
    }
}
