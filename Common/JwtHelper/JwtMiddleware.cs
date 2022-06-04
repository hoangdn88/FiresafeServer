using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Common.JwtHelper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger logger;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            logger = Serilog.Log.ForContext<JwtMiddleware>();
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userName = jwtUtils.ValidateToken(token, context);

            await _next(context);

        }
    }
}
