using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories.Interfaces
{
    public interface IDeviceInfoRepository : IMongoDbBase<DeviceInfo>
    {
        Task<DeviceInfo> GetByIMEI(string imei);
        Task<List<DeviceInfo>> GetDeviceInfos4Report(SearchReport search);
    }
}
