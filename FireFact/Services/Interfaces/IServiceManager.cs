namespace FireFact.Services.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        ITestResultService TestResultService { get; }
        IDeviceTypeService DeviceTypeService { get; }
        IErrorInfoService ErrorInfoService { get; }
        IReportService ReportService { get; }
    }
}