using Common.Entities.DataTransferObjects.Api;
using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class SMSService : Base, ISMSService
    {
        private string apiKey;

        public SMSService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("SMSService:BaseUrl");
            apiKey = Configuration.GetValue<string>("SMSService:ApiKey");

            if (BaseUrl.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendSMS(string phoneNumber, string message)
        {
            var smsRequest = new SMSRequest
            {
                ApiKey = apiKey,
                Content = message,
                ToNumber = phoneNumber
            };

            var (result, data) = await SendRequest<SMSServiceResponse>("SendSMS", smsRequest, RestSharp.Method.Post);

            Log.Information($"Send SMS to {phoneNumber}, content: {message}, result: {data}");

            if (result == System.Net.HttpStatusCode.OK && data.ErrorCode == ErrorCode.OK)
                return true;

            return false;
        }
    }
}
