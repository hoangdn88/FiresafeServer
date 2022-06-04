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
    public interface IUserService
    {
        public Task<bool> CreateActionAuditAsync(CreateUserActionDto createUserActionDto);
        public Task<List<Role>> GetRoleByListId(List<string> lstId);
        public Task<List<UserDto>> GetUserByListUserName(List<string> lstUserName);
    }
}
