using Common.Entities.DataTransferObjects.Api.Alert;
using Common.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FireHandlerService : Base, Interfaces.IFireHandlerService
    {
        public FireHandlerService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("FireHandlerServer:BaseUrl");
            if (BaseUrl.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public Task<List<FireAlertInfoDto>> GetAllFireByUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FireAlertInfoDto>> GetCurrentFireAlertByConstruction(List<string> constructionId)
        {
            var (result, fires) = await SendRequest<List<FireAlertInfoDto>>("api/alert/active", constructionId, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fires;

            else return null;
        }

        public async Task<List<FireAlertInfoDto>> GetAllFireAlertByConstruction(List<string> constructionId)
        {
            var (result, fires) = await SendRequest<List<FireAlertInfoDto>>("api/alert/constructions", constructionId, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fires;

            else return null;
        }

        public Task<List<FireAlertInfoDto>> GetFireByCity(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<FireAlertInfoDto> GetFireById(string id)
        {
            var (result, fires) = await SendRequest<FireAlertInfoDto>($"api/alert/id/{id}", string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fires;

            else return null;
        }
    }
}
