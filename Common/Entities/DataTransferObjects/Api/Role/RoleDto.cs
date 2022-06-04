using Common.Entities.Enum;
using Common.Entities.Models;
using System.Collections.Generic;

namespace Common.Entities.DataTransferObjects.Api
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Information { get; set; }
        public string CustomerId { get; set; }
        public List<UserPermission> Permissions { get; set; }

        public string CreateBy { get; set; }
        public RoleType RoleType { get; set; }
    }
}