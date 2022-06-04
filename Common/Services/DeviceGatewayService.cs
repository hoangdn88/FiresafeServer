using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Device;
using Common.Entities.Models;
using Common.Entities.Models.Device;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class DeviceGatewayService : Base, Interfaces.IDeviceGatewayService
    {
        public DeviceGatewayService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("DeviceGatewayServer:BaseUrl");
            if(BaseUrl.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<DeviceHardwareInfo> GetDeviceByImei(string imei, PermissionParam permission)
        {
            var (result, deviceInfo) = await SendRequest<DeviceHardwareInfo>("api/device-gateway/imei/" + imei, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return deviceInfo;

            else return null;
        }

        public async Task<List<DeviceHardwareInfo>> GetDeviceByConstructions(List<string> constructionIds, PermissionParam permission)
        {
            var result = await SendRequest<List<DeviceHardwareInfo>>("api/device-gateway/constructions", constructionIds, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result.Item1 == System.Net.HttpStatusCode.OK)
                return result.Item2;

            else return null;
        }

        public async Task<bool> UpdateDevice(DeviceHardwareUpdateDto deviceInfo, PermissionParam permission)
        {
            var result = await SendRequest<bool>("api/device-gateway", deviceInfo, RestSharp.Method.Put,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result.Item1 == System.Net.HttpStatusCode.OK)
                return result.Item2;

            else return false;
        }

        public async Task<bool> InsertListDevice(List<DeviceHardwareUpdateDto> deviceInfo, PermissionParam permission)
        {
            var result = await SendRequest<bool>("api/device-gateway/insertListDevice", deviceInfo, RestSharp.Method.Post,
                    new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result.Item1 == System.Net.HttpStatusCode.OK)
                return result.Item2;

            else return false;
        }
    }
}
