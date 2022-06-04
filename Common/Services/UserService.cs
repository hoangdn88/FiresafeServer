using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class UserService : Base, IUserService
    {
        private string Key;
        public UserService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("AuthServer:BaseUrl");
            if (BaseUrl?.EndsWith('/') == false) BaseUrl += '/';
        }

        public async Task<bool> CreateActionAuditAsync(CreateUserActionDto createUserActionDto)
        {
            if (createUserActionDto == null) createUserActionDto = new();
            var (result, _) = await SendRequest<NullClass>("api/UserAction/create", createUserActionDto, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            return (result == System.Net.HttpStatusCode.OK);
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetRoleByListId(List<string> lstId)
        {
            if (lstId == null) lstId = new();
            var (result, roles) = await SendRequest<List<Role>>("api/role/roles", lstId, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return roles?.Adapt<List<Role>>();

            else return null;
        }

        public async Task<List<UserDto>> GetUserByListUserName(List<string> lstUserName)
        {
            if (lstUserName == null) lstUserName = new();
            var (result, userName) = await SendRequest<List<Role>>("api/users/get-user-by-list-username", lstUserName, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return userName?.Adapt<List<UserDto>>();

            else return null;
        }
    }
}
