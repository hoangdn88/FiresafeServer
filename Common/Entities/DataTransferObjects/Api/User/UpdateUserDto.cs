using Common.Entities.Enum;
using Common.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UpdateUserDto : UpdateBase
    {        

        public string FullName { get; set; }
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "tên đăng nhập không đúng định dạng")]
        public string UserName { get; set; }
        //public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerId { get; set; }
        public List<string> RoleIds { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public UserActive IsActive { get; set; }
        public List<string> ConstructionId { get; set; }
        public List<LocationInfoDto> Locations { get; set; }
        public string PcccUnitId { get; set; }
        //public List<RoleType> RoleType { get; set; }
    }
}