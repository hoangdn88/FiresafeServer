using System;
using Microsoft.Extensions.Configuration;
using FireFact.Repositories.Interfaces;

namespace FireFact.Repositories
{
    using FireFact.Repositories.Interfaces;
    using MongoDB.Driver;

    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> lazyUserRepository;
        private readonly Lazy<IDeviceTypeRepository> lazyDeviceRepository;
        private readonly Lazy<IErrorInfoRepository> lazyErrorInfoRepository;
        private readonly Lazy<ITestResultRepository> lazyTestResultRepository;
        private readonly Lazy<IDeviceInfoRepository> lazyDeviceInfoRepository;

        public RepositoryManager(IConfiguration configuration, IMongoDatabase mongoDatabase)
        {
            lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(configuration, mongoDatabase));
            lazyDeviceRepository = new Lazy<IDeviceTypeRepository>(() => new DeviceTypeRepository(configuration, mongoDatabase));
            lazyErrorInfoRepository = new Lazy<IErrorInfoRepository>(() => new ErrorInfoRepository(configuration, mongoDatabase));
            lazyTestResultRepository = new Lazy<ITestResultRepository>(() => new TestResultRepository(configuration, mongoDatabase));
            lazyDeviceInfoRepository = new Lazy<IDeviceInfoRepository>(() => new DeviceInfoRepository(configuration, mongoDatabase));
        }

        public IUserRepository UserRepository => lazyUserRepository.Value;

        public IDeviceTypeRepository DeviceRepository => lazyDeviceRepository.Value;

        public IErrorInfoRepository ErrorInfoRepository => lazyErrorInfoRepository.Value;

        public ITestResultRepository TestResultRepository => lazyTestResultRepository.Value;

        public IDeviceInfoRepository DeviceInfoRepository => lazyDeviceInfoRepository.Value;
    }
}