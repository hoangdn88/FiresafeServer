using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using Common.JwtHelper;
using Common.Utils;
using FireFact.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Controllers
{
    [ApiController]
    [Route("api/firesafe")]
    public class TestResultController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        //private readonly Serilog.ILogger logger;

        //private string currentUserName => HttpContext.Items["UserName"]?.ToString();
        //private string currentCustomerId => HttpContext.Items["CustomerId"]?.ToString();

        public TestResultController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            //logger = Serilog.Log.ForContext<TestResultController>();
        }

        [HttpPost("test-result")]
        [AllowAnonymous]
        public async Task<IActionResult> TestResult([FromBody] List<TestResultDto> testResultDtos)
        {
            bool save = await serviceManager.TestResultService.MultiSaveAsync(testResultDtos);
            if (save)
                return Ok("Success");
            else
                return Ok("Fail");
        }
    }
}
