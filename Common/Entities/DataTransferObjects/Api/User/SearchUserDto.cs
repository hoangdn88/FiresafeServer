using Common.Entities.Enum;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchUserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerId { get; set; }
        public string RoleIds { get; set; }
        [Required(ErrorMessage = "Permissions không được để trống")]
        public UserPermission Permissions { get; set; }
        public UserActive IsActive { get; set; }
        public LocationInfoDto Locations { get; set; }
        public string PcccUnitId { get; set; }
        public string ConstructionId { get; set; }
    }
}