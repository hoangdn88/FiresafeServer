namespace Common.Entities.Models
{
    using Common.Entities.Enum;
    using System;
    using System.Collections.Generic;

    public class Role : Base
    {        
        public string RoleName { get; set; }
        public string Information { get; set; }
        public string CustomerId { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public RoleType RoleType { get; set; }
        public Role()
        {
        }
    }
}