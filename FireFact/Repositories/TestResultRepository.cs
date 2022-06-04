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
    public class TestResultRepository : MongoDbBase<JigTestResult>, ITestResultRepository
    {
        public TestResultRepository(IConfiguration configuration, IMongoDatabase mongoDatabase) : base(configuration, mongoDatabase)
        {
        }

        public async Task<JigTestResult> GetByImeiAndErrorCode(string imei, string errorCode)
        {
            var filter = Builders<JigTestResult>.Filter.Where(x => x.DeleteFlag == false);
            if (!string.IsNullOrEmpty(imei))
                filter &= Builders<JigTestResult>.Filter.Where(x => x.GsmIMEI == imei);
            if (!string.IsNullOrEmpty(errorCode))
                filter &= Builders<JigTestResult>.Filter.Where(x => x.ErrorCode.ToLower() == errorCode.ToLower());
            return (await Collection.FindAsync(filter))?.FirstOrDefault();
        }

        public async Task<List<JigTestResult>> GetErrorResult4Report(SearchReport search)
        {
            var filter = Builders<JigTestResult>.Filter.Where(x => x.DeleteFlag == false);
            if (!string.IsNullOrEmpty(search.DeviceTypeCode))
                filter &= Builders<JigTestResult>.Filter.Where(x => x.DeviceType == search.DeviceTypeCode);
            if (!string.IsNullOrEmpty(search.ErrorCode))
                filter &= Builders<JigTestResult>.Filter.Where(x => x.ErrorCode.ToLower() == search.ErrorCode.ToLower());
            if (search.FromDate != null)
                filter &= Builders<JigTestResult>.Filter.Where(x => x.DateTest >= new DateTime(search.FromDate.Value.Year, search.FromDate.Value.Month,
                search.FromDate.Value.Day));
            if (search.ToDate != null)
                filter &= Builders<JigTestResult>.Filter.Where(x => x.DateTest <= new DateTime(search.ToDate.Value.Year, search.ToDate.Value.Month,
                search.ToDate.Value.Day, 23, 59, 59));
            return (await Collection.FindAsync(filter))?.ToList();
        }
        
        public async Task<List<JigTestResult>> GetByImei(string imei)
        {
            var filter = Builders<JigTestResult>.Filter.Where(x => x.DeleteFlag == false);
            if (!string.IsNullOrEmpty(imei))
                filter &= Builders<JigTestResult>.Filter.Where(x => x.GsmIMEI == imei);
            return (await Collection.FindAsync(filter))?.ToList();
        }

    }
}
