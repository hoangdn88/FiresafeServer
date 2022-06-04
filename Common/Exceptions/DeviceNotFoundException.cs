namespace Common.Exceptions
{
    public class DeviceNotFoundException : NotFoundException
    {
        public DeviceNotFoundException(string id) : base($"The device with the imei/customer id {id} was not found.")
        {
        }
    }
}