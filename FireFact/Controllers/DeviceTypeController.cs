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
using Common.JwtHelper;
using Common.Entities.Models;
using Common.Attributes;

namespace FireFact.Controllers
{
    [ApiController]
    [Route("api/device-type")]
    [Tags("Device type management")]
    public class DeviceTypeController : ControllerBase
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

        public DeviceTypeController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            //logger = Serilog.Log.ForContext<DeviceTypeController>();
        }

        //[HttpGet("get-all")]
        //[Authorize(UserPermission.FACT_VIEW)]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    List<DeviceTypeInfo> deviceTypeInfos = await serviceManager.DeviceTypeService.GetAllByCode("");
        //    if(deviceTypeInfos != null)
        //        return Ok(deviceTypeInfos);
        //    return Ok(new List<DeviceTypeInfo>());
        //}

        [HttpGet("search-by-code")]
        //[Authorize(UserPermission.FACT_VIEW)]
        [AllowAnonymous]
        public async Task<IActionResult> SearchDevice(string code, CancellationToken cancellationToken)
        {
            var pageOption = Request.Headers["PageOption"].ToString();
            var option = JsonConvert.DeserializeObject<PageParametersDto>(pageOption);
            OptionalParam<PageParametersDto> optionalParam = null;
            if(option != null && option.Paging)
            {
                optionalParam = new();
                optionalParam.Value = option;
                List<DeviceTypeResponseDto> deviceTypes = await serviceManager.DeviceTypeService.GetAllByCode(code, optionalParam);
                if (deviceTypes == null) return Ok(new List<DeviceTypeResponseDto>());
                ApiPaginationWrapperDto pagingDto = new(optionalParam.Value);
                pagingDto.Data = new List<object>(deviceTypes);
                return Ok(pagingDto);
            }
            else
            {
                List<DeviceTypeResponseDto> deviceTypes = await serviceManager.DeviceTypeService.GetAllByCode(code);
                if (deviceTypes == null) return Ok(new List<DeviceTypeResponseDto>());
                return Ok(deviceTypes);
            }
        }

        [HttpGet("get-by-id/{id}")]
        [Authorize(UserPermission.FACT_VIEW)]
        public async Task<IActionResult> GetDetail(string id, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest(MessageError.ErrorIdNotExits);

            DeviceTypeResponseDto deviceInfo = await serviceManager.DeviceTypeService.GetById(id, cancellationToken);
            if (deviceInfo != null)
                return Ok(deviceInfo);
            return NoContent();
        }

        [HttpPost("create")]
        [Authorize(UserPermission.FACT_EDIT)]
        [LogUserAction("Thêm mới loại thiết bị")]
        public async Task<IActionResult> CreateAsync([FromBody] DeviceTypeInfoDto deviceTypeInfoDto, CancellationToken cancellationToken)
        {
            if (deviceTypeInfoDto == null) return BadRequest(MessageError.ErrorCreate);
            if(string.IsNullOrEmpty(deviceTypeInfoDto.DeviceTypeCode))
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.DeviceCodeNotFound);
            bool existcode = await serviceManager.DeviceTypeService.IsExistCode(deviceTypeInfoDto.DeviceTypeCode.Trim());
            if(existcode)
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.DeviceCodeExits);
            bool save = await serviceManager.DeviceTypeService.InsertAsync(deviceTypeInfoDto, currentUserName, cancellationToken);
            if (save)
                return StatusCode((int)HttpStatusCode.OK, MessageError.CreateSuccess);

            return BadRequest(MessageError.ErrorCreate);
        }

        [HttpPut("update")]
        [Authorize(UserPermission.FACT_EDIT)]
        [LogUserAction("Cập nhật loại thiết bị")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDeviceTypeInfoDto deviceTypeInfoDto, CancellationToken cancellationToken)
        {
            if (deviceTypeInfoDto == null) return BadRequest(MessageError.ErrorUpdate);
            if (string.IsNullOrEmpty(deviceTypeInfoDto.DeviceTypeCode))
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.DeviceCodeNotFound);
            bool existcode = await serviceManager.DeviceTypeService.IsExistCode(deviceTypeInfoDto.DeviceTypeCode.Trim(), deviceTypeInfoDto.Id);
            if(existcode)
                return StatusCode((int)HttpStatusCode.BadRequest, MessageError.DeviceCodeExits);
            bool save = await serviceManager.DeviceTypeService.UpdateAsync(deviceTypeInfoDto, currentUserName, cancellationToken);
            if(save)
                return StatusCode((int)HttpStatusCode.OK, MessageError.UpdateSuccess);

            return BadRequest(MessageError.ErrorUpdate);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(UserPermission.FACT_DELETE)]
        [LogUserAction("Xoá loại thiết bị")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest(MessageError.ErrorIdNotExits);
            bool del = await serviceManager.DeviceTypeService.DeleteAsync(id, currentUserName, cancellationToken);
            if(del)
                return StatusCode((int)HttpStatusCode.OK, MessageError.DeleteSuccess);

            return BadRequest(MessageError.DeleteFail);
        }
    }
}
