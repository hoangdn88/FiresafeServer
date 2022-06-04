using Common.Entities.Models.Fact;
using Common.MongoDbHelper.Interface;

namespace FireFact.Repositories.Interfaces
{
    public interface IReportRepository : IMongoDbBase<JigTestResult>
    {

    }
}
