using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.Exceptions;
using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using Serilog;

namespace Common.Services
{
    public abstract class Base : IInternalService
    {
        protected readonly IConfiguration Configuration;        
        protected string BaseUrl;
        protected byte[] JwtSecretToken;

        protected Base(IConfiguration configuration)
        {
            Configuration = configuration;

            JwtSecretToken = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:Key", "0"));
        }

        protected string GenerateToken()
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtSecretToken), SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                       new Claim("UserName", "InternalServer"),
                        new Claim("CustomerId", String.Empty),
                        new Claim("Constructions", JsonSerializer.Serialize(new List<string>())),
                        new Claim("Roles", JsonSerializer.Serialize(new List<string>())),
                        new Claim("PcccUnit", String.Empty),
                        new Claim("Permission",  JsonSerializer.Serialize(new List<UserPermission>{UserPermission.ADMIN})),
                        new Claim("Location", JsonSerializer.Serialize(new List<LocationInfo>())),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return $"Bear {tokenHandler.WriteToken(token)}";
        }

        protected string GenerateToken(PermissionParam permission)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtSecretToken), SecurityAlgorithms.HmacSha256Signature);
            //if (customerId != null && (userPermissions.Contains(UserPermission.CONSTRUCTION_VIEW) || userPermissions.Contains(UserPermission.CONSTRUCTION_EDIT)
            //            || userPermissions.Contains(UserPermission.CONSTRUCTION_DELETE) || userPermissions.Contains(UserPermission.ADMIN)))
            //{
            //    constructionIds = (await fireInventoryService.GetConstructionByCustomerId(customerId))?.Select(x => x.Id).ToList();
            //}
            if (permission == null) return GenerateToken();
            var tokenHandler = new JwtSecurityTokenHandler();
            if (permission.UserPermissions != null && permission.UserPermissions.Count > 0) permission.UserPermissions = null;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                       new Claim("UserName", !string.IsNullOrEmpty(permission?.UserName) ?  permission?.UserName : "InternalServer" ),
                        new Claim("CustomerId", permission?.CustomerId != null ? permission?.CustomerId : string.Empty),
                        new Claim("Constructions", permission?.UserPermissions != null && (permission.UserPermissions.Contains(UserPermission.CONSTRUCTION_VIEW) || permission.UserPermissions.Contains(UserPermission.CONSTRUCTION_EDIT)
                        || permission.UserPermissions.Contains(UserPermission.CONSTRUCTION_DELETE) || permission.UserPermissions.Contains(UserPermission.ADMIN))  ?
                        JsonSerializer.Serialize(permission?.ConstructionIds ?? new List<string>()) : JsonSerializer.Serialize(new List<string>())),
                        new Claim("Roles", permission?.Roles?.Count > 0 ? JsonSerializer.Serialize(permission?.Roles)  : JsonSerializer.Serialize(new List<string>())),
                        new Claim("PcccUnit", String.Empty),
                        new Claim("Permission", permission?.UserPermissions != null ? JsonSerializer.Serialize(permission?.UserPermissions) : JsonSerializer.Serialize(new List<UserPermission>{UserPermission.ADMIN} )),
                        new Claim("Location", permission?.LocationsPermission != null ? JsonSerializer.Serialize(permission?.LocationsPermission) : JsonSerializer.Serialize(new List<LocationInfo>())),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return $"Bear {tokenHandler.WriteToken(token)}";
        }

        public async Task<(HttpStatusCode, T)> SendRequest<T>(string url, Object body, Method method, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(url, method);
            request.RequestFormat = DataFormat.Json;

            if (headers != null)
            {
                foreach (var header in headers) request.AddHeader(header.Key, header.Value);
            }

            if (body != null) request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);

            try
            {
                if(typeof(T) == typeof(NullClass)) 
                {
                    return (response.StatusCode, default(T));
                }
                else if(response.StatusCode == HttpStatusCode.OK)
                {
                    var option = new JsonSerializerOptions();
                    option.PropertyNameCaseInsensitive = true;
                    option.Converters.Add(new JsonStringEnumConverter());
                    if (IsValidJson(response.Content))
                    {
                        var result = JsonSerializer.Deserialize<T>(response.Content, option);

                        return (response.StatusCode, result);
                    } else
                    {
                        return (response.StatusCode, default(T));
                    }

                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"${BaseUrl}{url}, ({response.StatusCode}), response: {response.Content}");
            }

            return (response.StatusCode, default(T));
        }

        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var tmpObj = JsonValue.Parse(strInput);
                    return true;
                }
                catch (Exception ex) 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public abstract Exception CreateException(string message);
    }

    public class NullClass
    {
    }

}