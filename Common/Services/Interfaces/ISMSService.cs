using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Device;
using Common.Entities.Models;
using Common.Entities.Models.Device;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface ISMSService
    {
        public Task<bool> SendSMS(string phoneNumber, string message);
    }
}
