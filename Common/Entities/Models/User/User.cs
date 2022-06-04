namespace Common.Entities.Models
{
    using Common.Entities.Enum;
    using System;
    using System.Collections.Generic;

    public class User : Base
    {        
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string CustomerId { get; set; }
        public List<string> RoleIds { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PaswordTimeReset { get; set; }
        public List<LocationInfo> Locations { get; set; }
        public string PcccUnitId { get; set; }
        public int InvalidPasswordCount { get; set; }
        public UserActive IsActive { get; set; }
        public List<string> ConstructionId { get; set; }

        public User()
        {
        }
    }
}