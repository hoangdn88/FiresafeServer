using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using System.Threading.Tasks;

namespace FireFact.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<AuthResponseDto> GenerateToken(User user);
        public Task<AuthResponseDto> RefreshToken(string token);
    }
}
