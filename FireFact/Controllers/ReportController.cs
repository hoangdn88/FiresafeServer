using Common.Entities.Const;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Device;
using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models;
using Common.JwtHelper;
using FireFact.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FireFact.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly Serilog.ILogger logger;

        private string currentUserName => HttpContext.Items["UserName"]?.ToString();
        private string currentCustomerId => HttpContext.Items["CustomerId"]?.ToString();
        private List<LocationInfo> locations => !string.IsNullOrEmpty(HttpContext.Items["Location"]?.ToString()) ? JsonConvert.DeserializeObject<List<LocationInfo>>(HttpContext.Items["Location"]?.ToString()) : new();
        private List<UserPermission> userPermissions => !string.IsNullOrEmpty(HttpContext.Items["Permission"]?.ToString()) ? JsonConvert.DeserializeObject<List<UserPermission>>(HttpContext.Items["Permission"]?.ToString()) : new();
        private List<string> roleIds => !string.IsNullOrEmpty(HttpContext.Items["Roles"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Roles"]?.ToString()) : new();
        private List<string> currentUserConstructions => !string.IsNullOrEmpty(HttpContext.Items["Constructions"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Constructions"]?.ToString()) : new();

        public ReportController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
            logger = Serilog.Log.ForContext<ReportController>();
        }

        [HttpPost("report-error-detail")]
        [Authorize(UserPermission.FACT_REPORT_VIEW)]
        public async Task<IActionResult> ErrorDetail([FromBody] SearchReport searchReport, CancellationToken cancellationToken)
        {
            DateTime dtnow = DateTime.Now;
            //Lay 15 ngay gan nhat
            if (searchReport.FromDate == null)
            {
                if (searchReport.ToDate != null)
                    searchReport.FromDate = searchReport.ToDate?.AddDays(-15);
                else
                    searchReport.FromDate = dtnow.AddDays(-15);
            }
            if(searchReport.ToDate == null)
            {
                if (searchReport.FromDate != null)
                    searchReport.ToDate = searchReport.FromDate?.AddDays(+15);
                else
                    searchReport.ToDate = dtnow;
            }

            /*var pageOption = Request.Headers["PageOption"].ToString();
            var option = JsonConvert.DeserializeObject<PageParametersDto>(pageOption);
            OptionalParam<PageParametersDto> optionalParam = null;
            if (option != null && option.Paging)
            {
                optionalParam = new();
                optionalParam.Value = option;
                ReportErrorDetailGSM report = await _serviceManager.ReportService.ReportErrorDetailGSM(searchReport, optionalParam);
                if (deviceTypes == null) return NotFound();
                ApiPaginationWrapperDto pagingDto = new(optionalParam.Value);
                pagingDto.Data = new List<object>(deviceTypes);
                return Ok(pagingDto);
            }
            else
            {
                ReportErrorDetailGSM report = await _serviceManager.ReportService.ReportErrorDetailGSM(searchReport, optionalParam);
                if (deviceTypes == null) return NotFound();
                return Ok(deviceTypes);
            }*/

            ReportErrorDetailGSM report = await _serviceManager.ReportService.ReportErrorDetailGSM(searchReport);
            if(report != null)
                return Ok(report);
            return NoContent();
        }

        [HttpGet("test-result-detail")]
        [Authorize(UserPermission.FACT_REPORT_VIEW)]
        public async Task<IActionResult> TestResultDetail(string imei, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(imei)) return BadRequest(MessageError.PairingDeviceIMEINotExits);
            var report = await _serviceManager.ReportService.ReportTestResultDetail(imei);
            if(report != null)
                return Ok(report);
            return NoContent();
        }

        [HttpPost("report-error-summary")]
        [Authorize(UserPermission.FACT_REPORT_VIEW)]
        public async Task<IActionResult> ReportSummaryError([FromBody] SearchReport searchReport, CancellationToken cancellationToken)
        {
            ReportErrorDetailGSM report = await _serviceManager.ReportService.ReportErrorSummary(searchReport);
            if (report != null)
                return Ok(report);
            return NoContent();
        }
    }
}
