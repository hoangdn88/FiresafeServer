using FireFact.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api.Fact;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Common.Entities.DataTransferObjects.Api;
using System.Collections.Generic;
using Common.Entities.Models.Fact;
using System.Net;
using Common.Entities.Const;
using Common.Attributes;
using Common.JwtHelper;
using Common.Entities.Models;
using System;

namespace FireFact.Controllers
{
    [ApiController]
    [Route("api/error-info")]
    [Tags("Error management")]
    public class ErrorInfoController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        //private readonly Serilog.ILogger logger;

        private string currentUserName => HttpContext.Items["UserName"]?.ToString();
        private string currentCustomerId => HttpContext.Items["CustomerId"]?.ToString();
        private List<LocationInfo> locations => !string.IsNullOrEmpty(HttpContext.Items["Location"]?.ToString()) ? JsonConvert.DeserializeObject<List<LocationInfo>>(HttpContext.Items["Location"]?.ToString()) : new();
        private List<UserPermission> userPermissions => !string.IsNullOrEmpty(HttpContext.Items["Permission"]?.ToString()) ? JsonConvert.DeserializeObject<List<UserPermission>>(HttpContext.Items["Permission"]?.ToString()) : new();
        private List<string> roleIds => !string.IsNullOrEmpty(HttpContext.Items["Roles"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Roles"]?.ToString()) : new();
        private List<string> currentUserConstructions => !string.IsNullOrEmpty(HttpContext.Items["Constructions"]?.ToString()) ? JsonConvert.DeserializeObject<List<string>>(HttpContext.Items["Constructions"]?.ToString()) : new();
        //private string currentCustomerId => HttpContext.Items["CustomerId"]?.ToString();

        public ErrorInfoController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            //logger = Serilog.Log.ForContext<ErrorInfoController>();
        }

        //[HttpGet("get-all")]
        //[Authorize(UserPermission.FACT_VIEW)]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    List<ErrorInfo> errorInfos = await serviceManager.ErrorInfoService.GetAllByCode("");
        //    if (errorInfos != null)
        //        return Ok(errorInfos);
        //    return NotFound();
        //}

        [HttpGet("search-by-code")]
        [Authorize(UserPermission.FACT_VIEW)]
        public async Task<IActionResult> Search(string code, CancellationToken cancellationToken)
        {
            var pageOption = Request.Headers["PageOption"].ToString();
            var option = JsonConvert.DeserializeObject<PageParametersDto>(pageOption);
            OptionalParam<PageParametersDto> optionalParam = null;
            if (option != null && option.Paging)
            {
                optionalParam = new();
                optionalParam.Value = option;
                List<ErrorInforResponseDto> errorInfos = await serviceManager.ErrorInfoService.GetAllByCode(code, optionalParam);
                if (errorInfos == null) return Ok(new List<ErrorInforResponseDto>());
                ApiPaginationWrapperDto pagingDto = new(optionalParam.Value);
                pagingDto.Data = new List<object>(errorInfos);
                return Ok(pagingDto);
            }
            else
            {
                List<ErrorInforResponseDto> errorInfos = await serviceManager.ErrorInfoService.GetAllByCode(code);
                if (errorInfos == null) return Ok(new List<ErrorInforResponseDto>());
                return Ok(errorInfos);
            }
        }

        [HttpGet("get-by-id/{id}")]
        [Authorize(UserPermission.FACT_VIEW)]
        public async Task<IActionResult> GetDetail(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(MessageError.ErrorIdNotExits);

            ErrorInforResponseDto errorInfo = await serviceManager.ErrorInfoService.GetById(id, cancellationToken);
            if (errorInfo != null)
                return Ok(errorInfo);

            return NoContent();
        }

        [HttpPost("create")]
        [Authorize(UserPermission.FACT_EDIT)]
        [LogUserAction("Thêm mới thông tin lỗi")]
        public async Task<IActionResult> CreateAsync([FromBody] ErrorInfoDto errorInfoDto, CancellationToken cancellationToken)
        {
            if (errorInfoDto == null) return BadRequest();
            if (string.IsNullOrEmpty(errorInfoDto.ErrorCode))
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.ErrorCodeNotFound);
            bool existcode = await serviceManager.ErrorInfoService.IsExistCode(errorInfoDto.ErrorCode.Trim());
            if (existcode)
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.ErrorCodeExits);

            //string id = "";
            //upload file
            //if (errorInfoDto.UploadedFile != null && errorInfoDto.UploadedFile.Count > 0)
            //{
            //    id = Guid.NewGuid().ToString();
            //    List<string> files = new();
            //    foreach(var file in errorInfoDto.UploadedFile)
            //    {
            //        var fileUrl = await serviceManager.ErrorInfoService.SendFileToS3(file, id);
            //        if (fileUrl != null)
            //            files.Add(fileUrl);
            //    }
            //    errorInfoDto.FileUrl = files;
            //}

            bool save = await serviceManager.ErrorInfoService.InsertAsync(errorInfoDto, currentUserName, cancellationToken);
            if (save)
                return StatusCode((int)HttpStatusCode.OK, MessageError.CreateSuccess);

            return BadRequest(MessageError.ErrorCreate);
        }

        [HttpPut("update")]
        [Authorize(UserPermission.FACT_EDIT)]
        [LogUserAction("Cập nhật thông tin lỗi")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateErrorInfoDto errorInfoDto, CancellationToken cancellationToken)
        {
            if (errorInfoDto == null) return BadRequest(MessageError.ErrorUpdate);
            if (string.IsNullOrEmpty(errorInfoDto.ErrorCode))
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.ErrorCodeNotFound);
            bool existcode = await serviceManager.ErrorInfoService.IsExistCode(errorInfoDto.ErrorCode.Trim(), errorInfoDto.Id);
            if (existcode)
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.ErrorCodeExits);
            //upload file
            //if (errorInfoDto.UploadedFile != null && errorInfoDto.UploadedFile.Count > 0)
            //{
            //    if (errorInfoDto.FileUrl == null)
            //        errorInfoDto.FileUrl = new();
            //    foreach (var file in errorInfoDto.UploadedFile)
            //    {
            //        var fileUrl = await serviceManager.ErrorInfoService.SendFileToS3(file, errorInfoDto.Id);
            //        if (fileUrl != null)
            //            errorInfoDto.FileUrl.Add(fileUrl);
            //    }
            //}
            bool save = await serviceManager.ErrorInfoService.UpdateAsync(errorInfoDto, currentUserName, cancellationToken);
            if (save)
                return StatusCode((int)HttpStatusCode.OK, MessageError.UpdateSuccess);

            return BadRequest(MessageError.ErrorUpdate);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(UserPermission.FACT_DELETE)]
        [LogUserAction("Xoá thông tin lỗi")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest(MessageError.ErrorIdNotExits);
            bool del = await serviceManager.ErrorInfoService.DeleteAsync(id, currentUserName, cancellationToken);
            if (del)
                return StatusCode((int)HttpStatusCode.OK, MessageError.DeleteSuccess);

            return BadRequest(MessageError.DeleteFail);
        }
    }
}
