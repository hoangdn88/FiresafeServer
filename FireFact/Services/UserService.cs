using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;
using Mapster;
using Common.Entities.Models;
using Common.Exceptions;
using FireFact.Repositories.Interfaces;

namespace FireFact.Services
{
    using Interfaces;
    using Serilog;

    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ITokenService tokenService;

        public UserService(IRepositoryManager repositoryManager, ITokenService tokenService)
        {
            this.repositoryManager = repositoryManager;
            this.tokenService = tokenService;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await repositoryManager.UserRepository.GetAllAsync();

            var usersDto = users.Adapt<IEnumerable<UserDto>>();

            return usersDto;
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto loginRequest, CancellationToken cancellationToken = default)
        {
            var existingUser = await repositoryManager.UserRepository.GetUserByUserNameAsync(loginRequest.UserName.ToLower().Replace(" ",""));
            
            if (existingUser == null || existingUser?.Password != Common.Utils.Convert.GetMD5Hash(loginRequest.Password))
            {
                Log.Information("User login: {@Request}, wrong user name or password", loginRequest);
                return null;
            }

            var token = await tokenService.GenerateToken(existingUser);

            Log.Information("User login: {@Request}, token: {@token}", loginRequest, token);

            return token;
        }

        public async Task<UserDto> GetByUserName(string userName, CancellationToken cancellationToken = default)
        {
            var user = await repositoryManager.UserRepository.GetUserByUserNameAsync(userName, cancellationToken);

            var userDto = user?.Adapt<UserDto>();

            return userDto;
        }

        public async Task<bool> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
        {
            var user = createUserDto.Adapt<User>();
            user.CreateTime = System.DateTime.Now;
            user.Password = Common.Utils.Convert.GetMD5Hash(user.Password);
            user.UserName = user.UserName.ToLower().Replace(" ", "");

            return await repositoryManager.UserRepository.UpdateAsync(x => x.UserName, user, true);
        }

        public async Task<List<User>> GetUserByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.UserRepository.GetUserByCustomerIdAsync(customerId);
        }

        public async Task<List<User>> GetUserByCustomerIdAsync(List<string> customerIds, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.UserRepository.GetUserByCustomerIdAsync(customerIds);
        }

        public async Task<bool> UpdateAsync(UpdateUserDto userForUpdateDto, CancellationToken cancellationToken = default)
        {
            var user = userForUpdateDto.Adapt<User>();

            return await repositoryManager.UserRepository.UpdateAsync(x => x.UserName, user, false);
        }

        public async Task<AuthResponseDto> RefreshToken(RefreshTokenRequestDto refreshTokenRequest, CancellationToken cancellationToken = default)
        {
            return await tokenService.RefreshToken(refreshTokenRequest.RefreshToken);
        }
    }
}