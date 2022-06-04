using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Device;
using Common.Entities.Models;
using Common.Entities.Models.Device;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IDeviceGatewayService
    {
        Task<List<DeviceHardwareInfo>> GetDeviceByConstructions(List<string> constructionIds, PermissionParam permission);
        Task<bool> UpdateDevice(DeviceHardwareUpdateDto deviceInfo, PermissionParam permission);
        Task<bool> InsertListDevice(List<DeviceHardwareUpdateDto> deviceInfo, PermissionParam permission);
        Task<DeviceHardwareInfo> GetDeviceByImei(string imei, PermissionParam permission);
    }
}
