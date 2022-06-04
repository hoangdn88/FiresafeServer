using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;

namespace FireFact.Services.Interfaces
{
    public interface IDeviceTypeService
    {
        Task<bool> InsertAsync(DeviceTypeInfoDto deviceTypeInfoDto, string creator, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(UpdateDeviceTypeInfoDto deviceTypeInfoDto, string creator, CancellationToken cancellationToken = default);
        Task<List<DeviceTypeResponseDto>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null);
        Task<bool> DeleteAsync(string id, string creator, CancellationToken cancellationToken = default);
        Task<bool> IsExistCode(string code, string id = null);
        Task<DeviceTypeInfoDto> GetByCode(string code);
        Task<DeviceTypeResponseDto> GetById(string id, CancellationToken cancellationToken = default);
    }
}
