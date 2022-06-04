using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories.Interfaces
{
    public interface ITestResultRepository : IMongoDbBase<JigTestResult>
    {
        //Task<List<JigTestResult>> Search(string imei, string errorCode);
        Task<JigTestResult> GetByImeiAndErrorCode(string imei, string errorCode);
        Task<List<JigTestResult>> GetErrorResult4Report(SearchReport search);
        Task<List<JigTestResult>> GetByImei(string imei);
    }
}
