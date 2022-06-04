using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Device
{
    public class CreateDeviceInfoDto
    {
        [Required(ErrorMessage = "IMEI không được để trống")]        
        public string Imei { set; get; } // IMEI thiết bị

        [Required(ErrorMessage = "Tên thiết bị không được để trống")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Mã seri không được để trống")]
        public string SeriNumber { set; get; }

        [Required(ErrorMessage = "Công trình không được để trống")]
        public string ConstructionId { set; get; }

        [Required(ErrorMessage = "Loại thiết bị không được để trống")]
        public string LoaiThietBi { set; get; }
        public bool? IsActive { set; get; }

        public DateTime? ActiveTime { set; get; }
        public DateTime? ExpiredTime { set; get; }
    }
}
