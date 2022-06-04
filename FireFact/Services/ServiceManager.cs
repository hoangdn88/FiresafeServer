using System;
using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FireFact.Services
{
    using FireFact.Repositories.Interfaces;
    using FireFact.Services.Interfaces;

    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> lazyUserService;
        private readonly Lazy<ITestResultService> lazyResultService;
        private readonly Lazy<IDeviceTypeService> lazyDeviceTypeService;
        private readonly Lazy<IErrorInfoService> lazyErrorInfoService;
        private readonly Lazy<IReportService> lazyReportService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, ITokenService tokenService)
        {
            lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, tokenService));
            lazyResultService = new Lazy<ITestResultService>(() => new TestResultService(repositoryManager));
            lazyDeviceTypeService = new Lazy<IDeviceTypeService>(() => new DeviceTypeService(repositoryManager));
            lazyErrorInfoService = new Lazy<IErrorInfoService>(() => new ErrorInfoService(repositoryManager, configuration));
            lazyReportService = new Lazy<IReportService>(() => new ReportService(repositoryManager));
        }

        public IUserService UserService => lazyUserService.Value;

        public ITestResultService TestResultService => lazyResultService.Value;

        public IDeviceTypeService DeviceTypeService => lazyDeviceTypeService.Value;

        public IErrorInfoService ErrorInfoService => lazyErrorInfoService.Value;

        public IReportService ReportService => lazyReportService.Value;
    }
}