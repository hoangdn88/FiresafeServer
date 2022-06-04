using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class AuthRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        //public string Info { get; set; }
    }
    public class RefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; }
        public string Info { get; set; }
    }
}