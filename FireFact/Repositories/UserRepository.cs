using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.Models;
using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using FireFact.Repositories.Interfaces;
using MongoDB.Driver;
using Common.MongoDbHelper;

namespace FireFact.Repositories
{
    internal sealed class UserRepository : MongoDbBase<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration, IMongoDatabase mongoDatabase) : base(configuration, mongoDatabase)
        {
        }

        public async Task<User> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            return (await Collection.FindAsync(x => x.UserName == userName && x.DeleteFlag == false))?.FirstOrDefault();
        }

        public async Task<List<User>> GetUserByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default)
        {
            return (await Collection.FindAsync(x => x.CustomerId == customerId && x.DeleteFlag == false, cancellationToken: cancellationToken))?.ToList();
        }

        public async Task<List<User>> GetUserByCustomerIdAsync(List<string> customerIds, CancellationToken cancellationToken = default)
        {
            return (await Collection.FindAsync(x => customerIds.Contains(x.CustomerId) && x.DeleteFlag == false, cancellationToken: cancellationToken))?.ToList();
        }
    }
}