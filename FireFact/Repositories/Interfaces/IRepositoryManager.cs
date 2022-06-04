namespace FireFact.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IDeviceTypeRepository DeviceRepository { get; }
        IErrorInfoRepository ErrorInfoRepository { get; }
        ITestResultRepository TestResultRepository { get; }
        IDeviceInfoRepository DeviceInfoRepository { get; }
    }
}