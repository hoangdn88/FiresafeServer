using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories.Interfaces
{
    public interface IDeviceTypeRepository : IMongoDbBase<DeviceTypeInfo>
    {
        Task<List<DeviceTypeInfo>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null);
        Task<DeviceTypeInfo> GetByCode(string code);
    }
}
