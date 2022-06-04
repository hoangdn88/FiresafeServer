using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models.Fact;
using Common.MongoDbHelper.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Repositories.Interfaces
{
    public interface IErrorInfoRepository : IMongoDbBase<ErrorInfo>
    {
        Task<List<ErrorInfo>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null);
        Task<ErrorInfo> GetByCode(string code);
    }
}
