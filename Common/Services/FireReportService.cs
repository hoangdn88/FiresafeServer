using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Mapster;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FireReportService : Base, Interfaces.IFireReportService
    {
        public FireReportService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("FireReportServer:BaseUrl");
            if (BaseUrl.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateFireProtection(FireProtectionForUpdateDto fire)
        {
            if (fire == null) fire = new();
            var (result, _) = await SendRequest<NullClass>("api/FireProtection", fire, RestSharp.Method.Put,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            return (result == System.Net.HttpStatusCode.OK);
        }

        public async Task<List<FireProtectionDto>> GetAllFireProtectionByConstructions(List<string> ids)
        {

            var (result, fireProtection) = await SendRequest<List<FireProtectionDto>>("api/FireProtection/getAllByListConstruction", ids, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireProtection?.Adapt<List<FireProtectionDto>>();

            else return null;
        }

        public async Task<List<FireProtectionDto>> GetCurrentFireAlertByConstruction(List<string> ids)
        {
            var (result, fireProtection) = await SendRequest<List<FireProtectionDto>>("api/FireProtection/getCurrentFiringByConstruction", ids, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireProtection?.Adapt<List<FireProtectionDto>>();

            else return null;
        }

        public async Task<FireProtectionInfo> CheckIdFireProtection(string id)
        {
            var (result, fireProtection) = await SendRequest<FireProtectionInfo>("api/FireProtection/checkIdFireProtection?id=" + id, string.Empty, RestSharp.Method.Get,
            new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireProtection;

            else return null;
        }

        public async Task<FireProtectionDto> GetFireAlertById(string ids)
        {
            var (result, fireProtection) = await SendRequest<FireProtectionDto>("api/FireProtection/id=" + ids, string.Empty, RestSharp.Method.Get,
            new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireProtection?.Adapt<FireProtectionDto>();

            else return null;
        }
    }
}
