using Common.Entities.DataTransferObjects.Api;
using Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        public CacheAttribute(int timeToLiveSeconds = 15)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
 
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var cache = context.HttpContext.RequestServices.GetService<IDistributedCache>();
                // get request body
                string stringContent = string.Empty;
                try
                {
                    context.HttpContext.Request.EnableBuffering();
                    context.HttpContext.Request.Body.Position = 0;
                    using (var reader = new StreamReader(context.HttpContext.Request.Body))
                    {
                        stringContent = await reader.ReadToEndAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                //
                var userName = context.HttpContext.Items["UserName"]?.ToString();
                var cacheKey = GenCacheKeyFromRequestAsync(context.HttpContext.Request, stringContent, userName);
                var cacheRespone = await cache.GetStringAsync(cacheKey);
                // check have cache
                if (!string.IsNullOrEmpty(cacheRespone))
                {
                    var contentResult = new ContentResult
                    {
                        Content = cacheRespone.ToString(),
                        ContentType = "application/json",
                        StatusCode = 200,
                    };
                    context.Result = contentResult;
                    return;
                }

                // if dont have cache => call api
                var excutedContext = await next();
                // save result to redis
                if (excutedContext.Result is OkObjectResult objectResult)
                    await cache.Save(cacheKey, objectResult.Value, _timeToLiveSeconds);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception CacheAttribute: "+ex.ToString());
            }
           
        }

        private static string GenCacheKeyFromRequestAsync(HttpRequest request, string stringContent, string userName)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{userName}");
            keyBuilder.Append($"{request.Path}");
            var pageOption = request.Headers["PageOption"].ToString();
            if (request.Method != null && request.Method=="GET")
            {
                foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                {
                    keyBuilder.Append($"|{key}--{value}");
                }
            }
            else if (request.Method != null &&( request.Method=="POST" ||  request.Method=="PUT"))
            {

                keyBuilder.Append($"|{stringContent}");
            }
            keyBuilder.Append($"|{pageOption}");
            return Base64Encode(keyBuilder.ToString());
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
