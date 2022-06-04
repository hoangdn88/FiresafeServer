using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerId { get; set; }
        public int InvalidPasswordCount { get; set; }
        public DateTime PaswordTimeReset { get; set; }
        public List<string> RoleIds { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public UserActive IsActive { get; set; }
        public List<LocationInfo> Locations { get; set; }
        public string PcccUnitId { get; set; }
        public List<string> ConstructionId { get; set; }
    }
}