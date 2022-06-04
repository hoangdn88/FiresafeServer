using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common.Utils;
using System.Security.Claims;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace Common.JwtHelper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params UserPermission[] permission) : base(typeof(AuthorizeFilter))
        {
            this.Arguments = new object[]
           {
                permission
           };
        }

        public class AuthorizeFilter : IAuthorizationFilter
        {

           // private readonly IUserService userService;
            private readonly UserPermission[] requirePermission;
            public AuthorizeFilter(
                // IUserService userService,
                 UserPermission[] permission
                )
            {

               // this.userService = userService;
                requirePermission = permission;
            }
            public async void OnAuthorization(AuthorizationFilterContext context)
            {
                try
                {
                    var cache = context.HttpContext.RequestServices.GetService<IDistributedCache>();
                    // skip authorization if action is decorated with [AllowAnonymous] attribute
                    var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
                    if (allowAnonymous)
                        return;

                    // authorization
                    var userName = context.HttpContext.Items["UserName"]?.ToString();

                    if (string.IsNullOrEmpty(userName))
                    {
                        //context.Result = new UnauthorizedResult();
                        context.Result = new ObjectResult($"Unauthorized")
                        {
                            StatusCode = (int)HttpStatusCode.Unauthorized

                        };
                        return;
                    }

                    else
                    {
                        // get contruction từ redis
                        var keyContruction = $"CONTRUCTIONIDS_{userName}";
                        string contructions = cache.GetString(keyContruction);
                        // add lại contruction vào claim từ redis
                        if (contructions!= null)
                        {
                            var key = contructions.Replace('\\', ' ').Substring(1, contructions.Length-2).Replace(" ", "");
                            context.HttpContext.Items.Remove("Constructions");
                            context.HttpContext.Items.Add("Constructions", key);
                        }
                        // get loaction từ redis
                        var keyLocations = $"LOCATIONS_{userName}";
                        string locations = cache.GetString(keyLocations);
                        // add lại location vào claim từ redis
                        if (locations!= null)
                        {
                            var key = locations.Replace('\\', ' ').Substring(1, locations.Length-2).Replace(" ", "");
                            context.HttpContext.Items.Remove("Location");
                            context.HttpContext.Items.Add("Location", key);
                        }
                        // Check permissions
                        var userPermision = context.HttpContext.Items["Permission"]?.ToString();
                        var role = context.HttpContext.Items["Roles"]?.ToString();

                        if (!string.IsNullOrEmpty(userPermision) || !string.IsNullOrEmpty(role))
                        {
                            var userPermissions = JsonConvert.DeserializeObject<List<UserPermission>>(userPermision);

                            if (userPermissions?.Count > 0 && userPermissions.Contains(UserPermission.ADMIN)) return;

                            // get permistion từ redis
                            if (!string.IsNullOrEmpty(role))
                            {
                                var roleIds = JsonConvert.DeserializeObject<List<string>>(role);
                                foreach (var id in roleIds)
                                {
                                    var key = $"ROLE_{id}";
                                    List<UserPermission> permisstionRedis = new List<UserPermission>();

                                    var data = cache.GetString(key);
                                    if (!string.IsNullOrEmpty(data))
                                        permisstionRedis = JsonConvert.DeserializeObject<List<UserPermission>>(data);


                                    if (permisstionRedis != null)
                                    {
                                        //permisstionRedis = null;
                                        userPermissions = userPermissions.Union(permisstionRedis).ToList();
                                    }
                                }
                            }


                            foreach (var tmpRequirePermission in requirePermission)
                            {
                                if (userPermissions?.Count > 0 && !userPermissions.Contains(tmpRequirePermission))
                                {
                                    context.Result = new ObjectResult($"Bạn cần có quyền '{tmpRequirePermission}'.")
                                    {
                                        StatusCode = (int)HttpStatusCode.Forbidden

                                    };
                                    return;
                                }
                            }
                        }
                        else
                        {
                            context.Result = new ObjectResult($"Bạn cần có quyền '{requirePermission[0]}'.")
                            {
                                StatusCode = (int)HttpStatusCode.Forbidden
                            };
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception AuthorizeAttribute: "+ex.ToString());
                }
               
            }

            
        }
    }
}
