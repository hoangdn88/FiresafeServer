using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Common.Attributes
{
    public class BasicAuthenticationFilter : IAuthorizationFilter
    {
        private readonly string validUsername;
        private readonly string validPassword;

        public BasicAuthenticationFilter(IConfiguration configuration)
        {
            validUsername = configuration.GetValue<string>("InternalServerAuthen:UserName");
            validPassword = configuration.GetValue<string>("InternalServerAuthen:Password");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                if (!IsCredentialsValid(username, password))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool IsCredentialsValid(string username, string password)
        {
            return validUsername == username && validPassword == password;
        }
    }

    public class BasicAuthenticationAttribute : TypeFilterAttribute
    {
        public BasicAuthenticationAttribute() : base(typeof(BasicAuthenticationFilter))
        {
        }
    }
}
