using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;

namespace FireFact.Services.Interfaces
{
    using Common.Entities.Models;

    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AuthResponseDto> Login(AuthRequestDto loginRequest, CancellationToken cancellationToken = default);
        Task<AuthResponseDto> RefreshToken(RefreshTokenRequestDto refreshTokenRequest, CancellationToken cancellationToken = default);
        Task<UserDto> GetByUserName(string userName, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(UpdateUserDto userForUpdateDto, CancellationToken cancellationToken);
        Task<List<User>> GetUserByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default);
        Task<List<User>> GetUserByCustomerIdAsync(List<string> customerIds, CancellationToken cancellationToken = default);
    }
}