using FireFact.Services.Interfaces;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FireFact.Services
{
    public class TokenService : ITokenService
    {
        int accessTokenExpireTime, refreshTokenExpireTime;
        string jwtSecretToken;
        private readonly SigningCredentials signingCredentials;

        IFireInventoryService fireInventoryService;

        public TokenService(IConfiguration configuration, IFireInventoryService fireInventoryService)
        {
            this.fireInventoryService = fireInventoryService;

            jwtSecretToken = configuration.GetValue<string>("Jwt:Key", "0");

            accessTokenExpireTime = configuration.GetValue<int>("Jwt:AccessTokenExpiredAfterMinutes", 1440);
            refreshTokenExpireTime = configuration.GetValue<int>("Jwt:RefreshTokenExpiredAfterMinutes", 14400);

            signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretToken)), SecurityAlgorithms.HmacSha256Signature);
        }

        public async Task<AuthResponseDto> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            PermissionParam permission = new()
            {
                LocationsPermission = user.Locations,
                UserPermissions = user.Permissions,
                CustomerId = user.CustomerId,
                UserName = user.UserName,
                Roles = user.RoleIds,
                ConstructionIds = user.ConstructionId

            };
            var constructionIds = (await fireInventoryService.GetConstructionByCustomerId(user.CustomerId, permission))?.Select(x => x.Id).ToList();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                    { 
                        new Claim("UserName", user.UserName),
                        new Claim("CustomerId", user.CustomerId ?? String.Empty),
                        new Claim("Constructions", JsonConvert.SerializeObject(constructionIds ?? new List<string>())),
                        new Claim("Roles", JsonConvert.SerializeObject(user.RoleIds ?? new List<string>())),
                        new Claim("PcccUnit", user.PcccUnitId ?? String.Empty),
                        new Claim("Location", JsonConvert.SerializeObject(user.Locations ?? new List<LocationInfo>())),
                        new Claim("Permission", JsonConvert.SerializeObject(new List<UserPermission>{UserPermission.ADMIN}))
                    }),
                Expires = DateTime.UtcNow.AddMinutes(accessTokenExpireTime),                
                SigningCredentials = signingCredentials
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            
            return new AuthResponseDto
            {
                AccessToken = accessToken,
                ExpirationTime = accessTokenExpireTime,
                RefreshToken = GenerateRefreshToken(user)
            };
        }

        private string GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("User", JsonConvert.SerializeObject(user?.Adapt<UserDto>()))
                    }),
                Expires = DateTime.UtcNow.AddMinutes(refreshTokenExpireTime),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<AuthResponseDto> RefreshToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretToken)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var user = jwtToken.Claims.First(x => x.Type == "User").Value;
                var responseToken = await GenerateToken(JsonConvert.DeserializeObject<User>(user));

                // return user id from JWT token if validation successful
                return responseToken;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
