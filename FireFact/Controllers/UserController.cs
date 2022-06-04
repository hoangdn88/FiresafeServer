using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;
using FireFact.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Common.JwtHelper;
using Common.Entities.Models;
using System.Net;
using Common.Entities.Const;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FireFact.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly Serilog.ILogger logger;

        private string currentUserName => HttpContext.Items["UserName"]?.ToString();
        private string currentCustomerId => HttpContext.Items["CustomerId"]?.ToString();
        private List<LocationInfo> locations => !string.IsNullOrEmpty(HttpContext.Items["Location"]?.ToString()) ? JsonConvert.DeserializeObject<List<LocationInfo>>(HttpContext.Items["Location"]?.ToString()) : new();
        private List<UserPermission> userPermissions => !string.IsNullOrEmpty(HttpContext.Items["Permission"]?.ToString()) ? JsonConvert.DeserializeObject<List<UserPermission>>(HttpContext.Items["Permission"]?.ToString()) : new();
        private List<string> roleIds => !string.IsNullOrEmpty(HttpContext.Items["Roles"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Roles"]?.ToString()) : new();
        private List<string> currentUserConstructions => !string.IsNullOrEmpty(HttpContext.Items["Constructions"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Constructions"]?.ToString()) : new();

        public UsersController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            logger = Serilog.Log.ForContext<UsersController>();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto loginRequest, CancellationToken cancellationToken)
        {
            var loginResult = await serviceManager.UserService.Login(loginRequest, cancellationToken);

            if (loginResult == null) return Unauthorized();

            return Ok(loginResult);
        }

        [HttpGet]
        [Authorize(UserPermission.USER_ACCOUNT_VIEW)]
        public async Task<IActionResult> GetUser(CancellationToken cancellationToken)
        {
            var user = await serviceManager.UserService.GetByUserName(currentUserName, cancellationToken);

            if (user == null)  return NotFound();

            return Ok(user);
        }

        [HttpGet("get-users")]
        [Authorize(UserPermission.USER_ACCOUNT_VIEW)]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var users = await serviceManager.UserService.GetAllAsync();

            return Ok(users);
        }

        [Authorize(UserPermission.USER_ACCOUNT_VIEW)]
        [HttpGet("get-user/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName, CancellationToken cancellationToken)
        {
            var userDto = await serviceManager.UserService.GetByUserName(userName, cancellationToken);
            if (userDto is null)
            {
                 return NotFound();
            }

            return Ok(userDto);
        }

        [Authorize(UserPermission.USER_ACCOUNT_EDIT)]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var result = await serviceManager.UserService.CreateAsync(createUserDto);

            if (result) return Ok();
            
            return BadRequest();
        }

        [Authorize(UserPermission.USER_ACCOUNT_EDIT)]
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto, CancellationToken cancellationToken)
        {
            if (await serviceManager.UserService.UpdateAsync(updateUserDto, cancellationToken)) return Ok();
            
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest, CancellationToken cancellationToken)
        {
            var refreshResult = await serviceManager.UserService.RefreshToken(refreshTokenRequest, cancellationToken);

            if (refreshResult != null)
                return Ok(refreshResult);

            return BadRequest();
        }
    }
}
