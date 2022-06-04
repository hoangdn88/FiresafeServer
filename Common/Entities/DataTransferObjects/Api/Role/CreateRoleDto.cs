using Common.Entities.Enum;
using Common.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Tên role không được để trống")]
        public string RoleName { get; set; }
        public string Information { get; set; }
        [Required(ErrorMessage = "Permissions không được để trống")]
        public List<UserPermission> Permissions { get; set; }
        //public string CreateBy { get; set; }
        //public RoleType RoleType { get; set; }
    }
}