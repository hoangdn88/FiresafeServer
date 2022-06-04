using Common.Entities.Enum;
using Common.Entities.Models;
using System.Collections.Generic;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UpdateRoleDto : UpdateBase
    {
        public string RoleName { get; set; }
        public string Information { get; set; }
        //public RoleType RoleType { get; set; }
        public List<UserPermission> Permissions { get; set; }

    }
}