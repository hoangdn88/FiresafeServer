using Common.Entities.Enum;
using Common.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Tên đầy đủ không được để trống")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username không được để trống")]
        [StringLength(20, MinimumLength =4, ErrorMessage = "tên đăng nhập không đúng định dạng")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password không được để trống")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "password không đúng định dạng")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CustomerID không được để trống")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "PhoneNumber không được để trống")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        public List<string> RoleIds { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public UserActive IsActive { get; set; }
        public List<LocationInfoDto> Locations { get; set; }
        public List<string> ConstructionId { get; set; }
        public string PcccUnitId { get; set; }
        //public List<RoleType> RoleType { get; set; }
    }
}