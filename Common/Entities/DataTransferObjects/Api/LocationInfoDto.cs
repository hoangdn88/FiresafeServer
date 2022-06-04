using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class LocationInfoDto
    {
        [JsonPropertyName("TinhThanh")]
        public string CityId { get; set; } // Mã Thành phố

        [JsonPropertyName("QuanHuyen")]
        public string DistrictId { get; set; } // Mã huyện

        [JsonPropertyName("XaPhuong")]
        public string WardId { get; set; } // Mã xã, phường
    }
}
