using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class AdminUpdatePassword
    {
        public string UserName { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "password không đúng định dạng")]
        public string NewPassword { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "password không đúng định dạng")]
        public string ReNewPassword { get; set; }
    }
}