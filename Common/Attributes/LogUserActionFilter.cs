using Common.Entities.DataTransferObjects.Api;
using Common.JwtHelper;
using Common.Services.Interfaces;
using Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Attributes
{
   

    public class LogUserActionAttribute : TypeFilterAttribute
    {
  
        public LogUserActionAttribute(params string[] parameterNames) : base(typeof(LogUserActionFilter))
        {
            this.Arguments = new object[]
           {
     
                parameterNames
           };
        }
        public class LogUserActionFilter : IAsyncActionFilter
        {

            private readonly IJwtUtils jwtUtils;
            //private readonly IUserService userService;
            private readonly string[] _parameterNames;
            public LogUserActionFilter(IJwtUtils jwtUtils
                //, IUserService userService
                , string[] parameterNames
                )
            {
                this.jwtUtils = jwtUtils;
                //this.userService = userService;
                _parameterNames = parameterNames;
            }
            async public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                try
                {
                    string query = null;
                    string userAgent = null;
                    int objectId = 0;
                    string response = null;
                    //get common infomation
                    var method = context.HttpContext.Request.Method;
                    var requestWithObjectId = method.Equals("POST") || method.Equals("PUT");

                    if (requestWithObjectId)
                    {
                        query = System.Text.Json.JsonSerializer.Serialize(context.HttpContext.Request?.Query);
                        if (context.HttpContext.Request != null && context.HttpContext.Request.Query != null && context.HttpContext.Request.Query.ContainsKey("id"))
                        {
                            _ = int.TryParse(context.HttpContext.Request.Query["id"].FirstOrDefault(), out objectId);
                        }
                    }
                    var path = context.HttpContext.Request.Path;
                    string ip = context.HttpContext.Connection?.RemoteIpAddress?.ToString();
                    var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                    //var userName = jwtUtils.ValidateToken(token, context.HttpContext);
              
                    var userName = this._parameterNames[0] == "Quên mật khẩu" ? "" : context.HttpContext.Items["UserName"]?.ToString();
          
                   

                    // Log request header
                    if (context.HttpContext.Request != null && context.HttpContext.Request.Headers != null && context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
                    {
                        userAgent = context.HttpContext.Request.Headers["User-Agent"];
                    }
                    // Log request header
                    // Log request body
                    context.HttpContext.Request.EnableBuffering();
                    context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    var buffer = new byte[System.Convert.ToInt32(context.HttpContext.Request.ContentLength)];
                    await context.HttpContext.Request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
                    var bodyAsText = Encoding.UTF8.GetString(buffer);
                    context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                    var isException = false;
                    Exception exception = null;
                    try
                    {
                        var excutedContext = await next();
                        var objResult = excutedContext.Result as ObjectResult;
                        if (objResult != null && objResult.Value != null)
                        {
                            response = objResult.Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        isException = true;
                        exception = ex;
                    }
                    finally
                    {

                        var actionAudit = new CreateUserActionDto
                        {
                            UserName = userName,
                            Path = path,
                            Action = method,
                            Parameter = query,
                            UserAgent = userAgent,
                            ObjectId = objectId,
                            NewObjectValue = bodyAsText,
                            Ip = ip,
                            AuditTime = DateTime.Now,
                            Response = response,
                            Message = this._parameterNames[0]
                        };
                        // Nếu lỗi khi gọi API lưu lại lỗi gì
                        if (isException)
                        {
                            actionAudit.ErrorMessage = $"{exception.Message}: \n {exception.StackTrace}";
                        }
                        // Thêm mới hành động vào ELK
                        if (requestWithObjectId)
                        {
                            Log.Information($"UserAction: {JsonConvert.SerializeObject(actionAudit)}");

                            //await userService.CreateActionAuditAsync(actionAudit);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Log.Error($"Exception LogUserActionAttribute: "+ex.ToString());
                }
              
            }
        }
    }
}
