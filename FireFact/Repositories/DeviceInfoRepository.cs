using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper;
using FireFact.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories
{
    public class DeviceInfoRepository : MongoDbBase<DeviceInfo>, IDeviceInfoRepository
    {
        public DeviceInfoRepository(IConfiguration configuration, IMongoDatabase mongoDatabase) : base(configuration, mongoDatabase)
        {
        }

        public async Task<DeviceInfo> GetByIMEI(string imei)
        {
            var filter = Builders<DeviceInfo>.Filter.Where(x => x.GsmIMEI == imei);
            return (await Collection.FindAsync(filter)).FirstOrDefault();
        }

        /// <summary>
        /// Tim kiem thong tin thiet bi theo dieu kien
        /// p/s: Error code: chi lay cac thiet bi test loi
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<List<DeviceInfo>> GetDeviceInfos4Report(SearchReport search)
        {
            var filter = new BsonDocument { { "DeleteFlag", false } };
            if (!string.IsNullOrEmpty(search.ErrorCode))
                filter.AddRange(new BsonDocument { { "TestResults." + search.ErrorCode, false } });
            if (!string.IsNullOrEmpty(search.DeviceTypeCode))
                filter.AddRange(new BsonDocument { { "DeviceType", search.DeviceTypeCode } });
            if (!string.IsNullOrEmpty(search.IMEI))
                filter.AddRange(new BsonDocument { { "GsmIMEI", search.IMEI } });
            FilterDefinition<DeviceInfo> filterDevice = filter;
            if (search.FromDate != null)
                filterDevice &= Builders<DeviceInfo>.Filter.Where(x => x.DateTest >= new DateTime(search.FromDate.Value.Year, search.FromDate.Value.Month,
                search.FromDate.Value.Day));
            if (search.ToDate != null)
                filterDevice &= Builders<DeviceInfo>.Filter.Where(x => x.DateTest <= new DateTime(search.ToDate.Value.Year, search.ToDate.Value.Month,
                search.ToDate.Value.Day, 23, 59, 59));

            return (await Collection.FindAsync(filter))?.ToList();
        }
    }
}
