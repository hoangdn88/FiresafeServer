using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UserUpdatePassword
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
        
        public string ReNewPassword { get; set; }
    }
}