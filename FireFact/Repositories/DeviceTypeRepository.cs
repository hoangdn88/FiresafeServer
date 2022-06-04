using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper;
using FireFact.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories
{
    public class DeviceTypeRepository : MongoDbBase<DeviceTypeInfo>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IConfiguration configuration, IMongoDatabase mongoDatabase) : base(configuration, mongoDatabase)
        {
        }

        /// <summary>
        /// Get list device type
        /// Code for search: if = null or empty > get all
        /// </summary>
        /// <param name="code">Device type code</param>
        /// <param name="paging"></param>
        /// <returns>list device type</returns>
        public async Task<List<DeviceTypeInfo>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null)
        {
            var filter = Builders<DeviceTypeInfo>.Filter.Where(x => x.DeleteFlag == false);
            if (!string.IsNullOrEmpty(code))
                filter &= Builders<DeviceTypeInfo>.Filter.Where(x => x.DeviceTypeCode.ToLower().Contains(code.ToLower()));
            if (paging != null && paging.Value != null && paging.Value.Paging)
            {
                var count = await Collection.CountDocumentsAsync(filter);
                paging.Value = new PageParametersDto((int)count, paging.Value.CurrentPage, paging.Value.PageSize);
                var options = new FindOptions<DeviceTypeInfo>();
                if (paging.Value.CurrentPage > 0)
                    options = new FindOptions<DeviceTypeInfo> { Limit = paging.Value.PageSize, Skip = (paging.Value.CurrentPage - 1) * paging.Value.PageSize };

                return (await Collection.FindAsync(filter, options))?.ToList();
            }
            else
                return (await Collection.FindAsync(filter))?.ToList();
        }

        public async Task<DeviceTypeInfo> GetByCode(string code)
        {
            var filter = Builders<DeviceTypeInfo>.Filter.Where(x => x.DeleteFlag == false && x.DeviceTypeCode == code);
            return (await Collection.FindAsync(filter)).FirstOrDefault();
        }
    }
}
