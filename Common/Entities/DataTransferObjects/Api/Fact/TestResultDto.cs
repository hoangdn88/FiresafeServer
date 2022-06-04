using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class TestResultDto
    {
        public int Timestamp { get; set; }
        public string DeviceType { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwardVersion { get; set; }
        public string MacJIG { get; set; }
        public string GsmIMEI { get; set; }
        public Dictionary<string, object> ErrorResults { get; set; }
        /*[JsonPropertyName("rs485")]
        public bool? Rs485 { get; set; }
        [JsonPropertyName("rs232")]
        public bool? Rs232 { get; set; }
        [JsonPropertyName("sim")]
        public bool? Sim { get; set; }
        [JsonPropertyName("eth")]
        public bool? Eth { get; set; }
        [JsonPropertyName("wifi")]
        public bool? Wifi { get; set; }
        [JsonPropertyName("server")]
        public bool? Server { get; set; }
        [JsonPropertyName("relay0")]
        public bool? Relay0 { get; set; }
        [JsonPropertyName("relay1")]
        public bool? Relay1 { get; set; }
        [JsonPropertyName("allPassed")]
        public bool? AllPassed { get; set; }
        [JsonPropertyName("temperature")]
        public bool? Temperature { get; set; }
        [JsonPropertyName("vin")]
        public bool? Vin { get; set; }
        [JsonPropertyName("vbat")]
        public bool? Vbat { get; set; }
        [JsonPropertyName("V1v8")]
        public bool? V1V8 { get; set; }
        [JsonPropertyName("V3v3")]
        public bool? V3V3 { get; set; }
        [JsonPropertyName("V5v")]
        public bool? V5V { get; set; }
        [JsonPropertyName("VGsm4v2")]
        public bool? VGsm4v2 { get; set; }
        [JsonPropertyName("charge")]
        public bool? Charge { get; set; }
        [JsonPropertyName("input")]
        public List<bool?> Input { get; set; }
        [JsonPropertyName("buttonTest")]
        public bool? ButtonTest { get; set; }
        [JsonPropertyName("alarmIn")]
        public bool? AlarmIn { get; set; }
        [JsonPropertyName("faultIn")]
        public bool? FaultIn { get; set; }
        [JsonPropertyName("sosButton")]
        public bool? SosButton { get; set; }
        [JsonPropertyName("mainPower")]
        public bool? MainPower { get; set; }
        [JsonPropertyName("backupPower")]
        public bool? BackupPower { get; set; }
        [JsonPropertyName("watchdog")]
        public bool? Watchdog { get; set; }*/
    }
}
