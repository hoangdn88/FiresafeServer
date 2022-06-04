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
    public class ErrorInfoRepository : MongoDbBase<ErrorInfo>, IErrorInfoRepository
    {
        public ErrorInfoRepository(IConfiguration configuration, IMongoDatabase mongoDatabase) : base(configuration, mongoDatabase)
        {
        }

        public async Task<List<ErrorInfo>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null)
        {
            var filter = Builders<ErrorInfo>.Filter.Where(x => x.DeleteFlag == false);
            if (!string.IsNullOrEmpty(code))
                filter &= Builders<ErrorInfo>.Filter.Where(x => x.ErrorCode.ToLower().Contains(code.ToLower()));
            if (paging != null && paging.Value != null && paging.Value.Paging)
            {
                var count = await Collection.CountDocumentsAsync(filter);
                paging.Value = new PageParametersDto((int)count, paging.Value.CurrentPage, paging.Value.PageSize);
                var options = new FindOptions<ErrorInfo>();
                if (paging.Value.CurrentPage > 0)
                    options = new FindOptions<ErrorInfo> { Limit = paging.Value.PageSize, Skip = (paging.Value.CurrentPage - 1) * paging.Value.PageSize };

                return (await Collection.FindAsync(filter, options))?.ToList();
            }
            else
                return (await Collection.FindAsync(filter))?.ToList();
        }

        public async Task<ErrorInfo> GetByCode(string code)
        {
            var filter = Builders<ErrorInfo>.Filter.Where(x => x.DeleteFlag == false && x.ErrorCode == code);
            return (await Collection.FindAsync(filter)).FirstOrDefault();
        }
    }
}
