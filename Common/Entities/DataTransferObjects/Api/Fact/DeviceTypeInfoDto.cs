using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class DeviceTypeInfoDto
    {
        [Required(ErrorMessage = "Mã loại thiết bị không được để trống!")]
        public string DeviceTypeCode { get; set; }
        public string Description { get; set; }
    }
}
