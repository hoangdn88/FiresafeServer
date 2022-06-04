using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long ExpirationTime { get; set; }
    }
}