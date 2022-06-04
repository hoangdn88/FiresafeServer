using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.Models;
using Common.MongoDbHelper.Interface;

namespace FireFact.Repositories.Interfaces
{
    public interface IUserRepository : IMongoDbBase<User> 
    {
        Task<User> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<List<User>> GetUserByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default);
        Task<List<User>> GetUserByCustomerIdAsync(List<string> customerIds, CancellationToken cancellationToken = default);
    }
}