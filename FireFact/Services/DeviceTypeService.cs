using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using FireFact.Repositories.Interfaces;
using FireFact.Services.Interfaces;
using Mapster;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FireFact.Services
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        //private readonly ITokenService tokenService;
        public DeviceTypeService(IRepositoryManager repositoryManager)//, ITokenService tokenService
        {
            this._repositoryManager = repositoryManager;
            //this.tokenService = tokenService;
        }

        public async Task<bool> DeleteAsync(string id, string creator, CancellationToken cancellationToken = default)
        {
            DeviceTypeInfo deviceTypeInfo = await _repositoryManager.DeviceRepository.GetByIndexAsync(x => x.Id, id, cancellationToken);
            if (deviceTypeInfo != null)
            {
                deviceTypeInfo.DeleteFlag = true;
                deviceTypeInfo.CreateTime = System.DateTime.Now;//use for time update
                deviceTypeInfo.Creator = creator;
                return await _repositoryManager.DeviceRepository.UpdateAsync(x => x.Id, deviceTypeInfo, false, cancellationToken);
            }

            return false;
        }

        public async Task<List<DeviceTypeResponseDto>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null)
        {
            var deviceType = await _repositoryManager.DeviceRepository.GetAllByCode(code, paging);
            if (deviceType != null)
                return deviceType.Adapt<List<DeviceTypeResponseDto>>();
            return null;
        }

        public async Task<DeviceTypeInfoDto> GetByCode(string code)
        {
            DeviceTypeInfo deviceTypeInfo = await _repositoryManager.DeviceRepository.GetByCode(code);
            if (deviceTypeInfo != null)
                return deviceTypeInfo.Adapt<DeviceTypeInfoDto>();
            return null;
        }

        public async Task<DeviceTypeResponseDto> GetById(string id, CancellationToken cancellationToken = default)
        {
            var deviceType = await _repositoryManager.DeviceRepository.GetByIndexAsync(x => x.Id, id, cancellationToken);
            if (deviceType != null)
                return deviceType.Adapt<DeviceTypeResponseDto>();
            return null;
        }

        public async Task<bool> InsertAsync(DeviceTypeInfoDto deviceTypeInfoDto, string creator, CancellationToken cancellationToken = default)
        {
            DeviceTypeInfo deviceTypeInfo = deviceTypeInfoDto.Adapt<DeviceTypeInfo>();
            deviceTypeInfo.CreateTime = System.DateTime.Now;
            deviceTypeInfo.Creator = creator;
            deviceTypeInfo.DeviceTypeCode = deviceTypeInfo.DeviceTypeCode.Trim();

            return await _repositoryManager.DeviceRepository.UpdateAsync(x => x.DeviceTypeCode, deviceTypeInfo, true, cancellationToken);
        }

        public async Task<bool> IsExistCode(string code, string id = null)
        {
            DeviceTypeInfo deviceTypeInfo = await _repositoryManager.DeviceRepository.GetByCode(code);
            if (deviceTypeInfo != null)
            {
                if (!string.IsNullOrEmpty(id) && deviceTypeInfo.Id == id)
                    return false;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(UpdateDeviceTypeInfoDto deviceTypeInfoDto, string creator, CancellationToken cancellationToken = default)
        {
            DeviceTypeInfo deviceTypeInfo = deviceTypeInfoDto.Adapt<DeviceTypeInfo>();
            deviceTypeInfo.CreateTime = System.DateTime.Now;//time for update
            deviceTypeInfo.Creator = creator;
            deviceTypeInfo.DeviceTypeCode = deviceTypeInfo.DeviceTypeCode.Trim();

            return await _repositoryManager.DeviceRepository.UpdateAsync(x => x.Id, deviceTypeInfo, false, cancellationToken);
        }
    }
}
