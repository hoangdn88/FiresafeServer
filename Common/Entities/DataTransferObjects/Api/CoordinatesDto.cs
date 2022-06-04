using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CoordinatesDto
    {
        [JsonPropertyName("lngstr")]
        public string Lngstr { set; get; }
        [JsonPropertyName("latstr")]
        public string Latstr { set; get; }
    }
}
