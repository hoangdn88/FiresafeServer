using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Common.JwtHelper
{
    public interface IJwtUtils
    {
        public string ValidateToken(string token, HttpContext context);
    }

    public class JwtUtils : IJwtUtils
    {
        string jwtSecretToken;

        public JwtUtils(IConfiguration configuration)
        {
            jwtSecretToken = configuration.GetValue<string>("Jwt:Key", "0");
        }
        public string ValidateToken(string token, HttpContext context)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecretToken);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                context.Items["UserName"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserName")?.Value;
                context.Items["CustomerId"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
                context.Items["Constructions"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "Constructions")?.Value;
                context.Items["Roles"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "Roles")?.Value;
                context.Items["PcccUnit"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "PcccUnit")?.Value;
                context.Items["Location"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "Location")?.Value;
                context.Items["Permission"] = jwtToken.Claims.FirstOrDefault(x => x.Type == "Permission")?.Value;

                // return user id from JWT token if validation successful
                return context.Items["UserName"].ToString();
            }
            catch(Exception ex)
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
