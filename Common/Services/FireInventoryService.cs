using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Mapster;
using System.Threading.Tasks;
using Common.Entities.Models.Device;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Common.Entities.DataTransferObjects.Api.Device;

namespace Common.Services
{
    public class FireInventoryService : Base, Interfaces.IFireInventoryService
    {
        public FireInventoryService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("FireInventoryServer:BaseUrl");
            if (BaseUrl?.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<DeviceInfoDto> GetDeviceByImei(string imei, PermissionParam permission)
        {
            var (result, deviceInfo) = await SendRequest<DeviceInfoDto>("api/devices/imei/" + imei, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return deviceInfo;

            else return null;
        }

        public async Task<CustomerInfo> GetCustomerById(string id, PermissionParam permission)
        {
            var (result, customerInfo) = await SendRequest<CustomerInfo>("api/customer/id=" + id, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return customerInfo;

            else return null;
        }

        public async Task<string> CreateConstruction(ConstructionForCreationDto construction, PermissionParam permission)
        {
            var (result, id) = await SendRequest<string>("api/construction", construction, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return id;

            else return string.Empty;
        }

        public async Task<ConstructionDto> GetConstructionById(string id, PermissionParam permission)
        {
            var (result, constructionInfo) = await SendRequest<ConstructionDto>("api/construction/id=" + id, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructionInfo?.Adapt<ConstructionDto>();

            else return null;
        }

        public async Task<List<ConstructionDto>> GetConstructionByLocation(LocationInfo location, PermissionParam permission)
        {
            if(location == null) location = new LocationInfo();
            var (result, constructionInfo) = await SendRequest<List<ConstructionDto>>("api/construction/searchByLocation", location.Adapt<LocationInfoDto>(), RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructionInfo;

            else return null;
        }

        public async Task<PcccUnitInfo> GetPcccUnitById(string id, PermissionParam permission)
        {
            var (result, pcccUnit) = await SendRequest<PcccUnitDto>("api/pcccUnit/id=" + id, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return pcccUnit?.Adapt<PcccUnitInfo>();

            else return null;
        }

        public async Task<StatisticDto> GetStatisticByConstructions(List<string> constructionIds, PermissionParam permission)
        {
            var (result, statistic) = await SendRequest<StatisticDto>("api/statistic/get-by-constructions", constructionIds, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return statistic;

            else return null;
        }

        public async Task<List<ConstructionDto>> GetConstructionByCustomerId(string id, PermissionParam permission)
        {
            // set token have CustomerId 
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtSecretToken), SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("UserName", "InteralSever"),
                        new Claim("CustomerId", $"{id}"),
                        new Claim("Permission", $"[{JsonConvert.SerializeObject(UserPermission.ADMIN)}]"),
                        new Claim("Location", JsonConvert.SerializeObject(permission?.LocationsPermission)),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokens = $"Bear {tokenHandler.WriteToken(token)}";
            //===
            var (result, constructions) = await SendRequest<List<ConstructionDto>>("api/construction/customer", string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", tokens } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }

        public async Task<List<SupportUnitDto>> GetSupportUnitsByPcccUnitId(string pcccUnitId, PermissionParam permission)
        {
            var (result, supportUnitDto) = await SendRequest<List<SupportUnitDto>>("api/supportUnit/pccc-unit-id=" + pcccUnitId, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return supportUnitDto;

            else return null;
        }

        public async Task<List<WaterPointDto>> GetWaterPointsByPcccUnitId(string pcccUnitId, PermissionParam permission)
        {
            var (result, waterPointDto) = await SendRequest<List<WaterPointDto>>("api/waterPoint/pccc-unit-id=" + pcccUnitId, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return waterPointDto;

            else return null;
        }

        public async Task<List<FireTruckDto>> GetFireTrucksByPcccUnitId(string pcccUnitId, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<List<FireTruckDto>>("api/fireTruck/pccc-unit-id=" + pcccUnitId, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }

        public async Task<List<ConstructionDto>> GetConstructionForReport(SearchConstructionDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructions) = await SendRequest<List<ConstructionDto>>("api/construction/searchForReport", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }

        public async Task<List<ConstructionDto>> GetAllConstructionById(List<string> ids, PermissionParam permission)
        {
            var (result, constructions) = await SendRequest<List<ConstructionDto>>("api/construction/constructionsByListId", ids, RestSharp.Method.Post,
             new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }

        public async Task<List<PcccUnitInfo>> GetAllPcccUnitById(List<string> ids, PermissionParam permission)
        {

            var (result, pcccUnit) = await SendRequest<List<PcccUnitDto>>("api/pcccUnit/getByListId", ids, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return pcccUnit?.Adapt<List<PcccUnitInfo>>();

            else return null;
        }
        public async Task<List<SupportUnitDto>> GetSupportUnitsByRadius(double longitude, double latitude, double radius, PermissionParam permission)
        {
            SearchRadius search = new()
            {
                Longitude = longitude,
                Latitude = latitude,
                Radius = radius,
            };
            var (result, data) = await SendRequest<List<SupportUnitDto>>($"api/supportUnit/search-by-radius", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }
        public async Task<List<WaterPointDto>> GetWaterPointsByRadius(double longitude, double latitude, double radius, PermissionParam permission)
        {
            SearchRadius search = new()
            {
                Longitude = longitude,
                Latitude = latitude,
                Radius = radius,
            };
            var (result, data) = await SendRequest<List<WaterPointDto>>($"api/waterPoint/search-by-radius", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }

        public async Task<List<PcccUnitDto>> SearchPcccUnitByLocation(LocationInfoDto location, PermissionParam permission)
        {
            SearchPcccUnitDto search = new()
            {
                Location = location,
            };
            var (result, data) = await SendRequest<List<PcccUnitDto>>("api/pcccUnit/search", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }

        public async Task<List<PcccUnitDto>> SearchPcccUnit(SearchPcccUnitDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, data) = await SendRequest<List<PcccUnitDto>>("api/pcccUnit/search", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }

        public async Task<List<CustomerInfo>> GetCustomerAndChilds(string customerId, PermissionParam permission)
        {
            // set token
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtSecretToken), SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("UserName", "InteralSever"),
                        new Claim("CustomerId", $"{customerId}"),
                        //new Claim("Permission", $"[{UserPermission.ADMIN}]")
                        new Claim("Permission", $"[{JsonConvert.SerializeObject(UserPermission.ADMIN)}]")
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokens =  $"Bear {tokenHandler.WriteToken(token)}";
            //===
            var (result, customerInfo) = await SendRequest<List<CustomerInfo>>("api/customer" , string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", tokens } });

            if (result == System.Net.HttpStatusCode.OK)
                return customerInfo;

            else return null;
        }

        public async Task<List<ConstructionDto>> GetConstructionByName(string name, PermissionParam permission)
        {
           if (name == null) name = string.Empty;
            var (result, constructions) = await SendRequest<List<ConstructionDto>>($"api/construction/getByName", name, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }

        public async Task<List<ConstructionDto>> GetAllConstruction(PermissionParam permission)
        {
            var (result, constructions) = await SendRequest<List<ConstructionDto>>("api/construction", string.Empty, RestSharp.Method.Get,
             new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }

        //public async Task<List<ConstructionDto>> GetAllByLocationAndCustomer(List<LocationInfo> locationPermissions = null, List<UserPermission> userPermissions = null, string customerId = null)
        //{
        //    var (result, constructions) = await SendRequest<List<ConstructionDto>>("api/construction/get-by-location-and-customer", string.Empty, RestSharp.Method.Get,
        //     new Dictionary<string, string> { { "Authorization", GenerateToken(locationPermissions, userPermissions, customerId) } });

        //    if (result == System.Net.HttpStatusCode.OK)
        //        return constructions;

        //    else return null;
        //}

        public async Task<List<ReportFireTruckInfo>> CountFireTruckStatusAsync(SearchDataReportFireTruckDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, fireTrucks) = await SendRequest<List<ReportFireTruckInfo>>($"api/fireTruck/countFireTruckStatus", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTrucks;

            else return null;
        }

        public async Task<List<FireTruckDto>> GetDataFireTruckAsync(SearchDataReportFireTruckDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, fireTrucks) = await SendRequest<List<FireTruckDto>>($"api/fireTruck/getDataFireTruckStatus", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTrucks;

            else return null;
        }

        public async Task<ApiPaginationWrapperDto> GetDataFireTruckPagingAsync(SearchDataReportFireTruckDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, fireTrucks) = await SendRequest<ApiPaginationWrapperDto>($"api/fireTruck/getDataFireTruckStatus", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTrucks;

            else return null;
        }

        public async Task<List<PcccUnitInfo>> GetAllPcccUnit(PermissionParam permission)
        {
            var (result, pcccUnit) = await SendRequest<List<PcccUnitDto>>("api/pcccUnit", string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return pcccUnit?.Adapt<List<PcccUnitInfo>>();

            else return null;
        }

        public async Task<List<WaterPointDto>> GetWaterPointsByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission)
        {
            var (result, data) = await SendRequest<List<WaterPointDto>>($"api/waterPoint/getByListPcccUnit", pcccUnitIds, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }

        public async Task<List<FireTruckDto>> GetFireTrucksByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<List<FireTruckDto>>("api/fireTruck/getByListPcccUnit", pcccUnitIds, RestSharp.Method.Post,
             new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }

        public async Task<List<FireFighterDto>> GetFireFighterByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<List<FireFighterDto>>("api/fireFighter/getByListPcccUnit", pcccUnitIds, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }

        public async Task<FireFighterDto> GetManagerByCityId(string cityId, PermissionParam permission)
        {
            var (result, fireFighterDto) = await SendRequest<FireFighterDto>("api/fireFighter/getManagerByCityId", cityId, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireFighterDto;

            else return null;
        }

        public async Task<List<DeviceInfoDto>> GetDeviceByConstructions(List<string> constructionIds, PermissionParam permission)
        {
            var (result, deviceDto) = await SendRequest<List<DeviceInfoDto>>("api/devices/getByConstruction", constructionIds, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return deviceDto;

            else return null;
        }

        public async Task<bool> UpdateFireTruck(FireTruckForUpdateDto fireTruck, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<bool>("api/fireTruck", fireTruck, RestSharp.Method.Put,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return false;
        }

        public Task<UserDto> GetUserByName(string userName, PermissionParam permission)
        {
            throw new NotImplementedException();
        }

        public async Task<FireTruckDto> GetFireTruckById(string id, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<FireTruckDto>("api/fireTruck/id="+ id, string.Empty, RestSharp.Method.Get,
                 new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }

        public async Task<DashBoardDto> GetDataDashBoard(LocationInfoDto location, PermissionParam permission)
        {
            var (result, data) = await SendRequest<DashBoardDto>("api/DashBoard/getData", location, RestSharp.Method.Post,
                 new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }


        public async Task<SupportUnitDto> GetSupportUnitsById(string supportId, PermissionParam permission)
        {
            var (result, supportUnitDto) = await SendRequest<SupportUnitDto>("api/supportUnit/id=" + supportId, string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return supportUnitDto;

            else return null;
        }

        public async Task<List<FireFighterDto>> SearchFireFighter(SearchByForPcccUnitScreen search, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<List<FireFighterDto>>("api/fireFighter/getByPcccUnitAndLocation", search, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }

        public async Task<List<SupportUnitDto>> GetSupportUnitsByListId(List<string> ids, PermissionParam permission)
        {
            var (result, supportUnitDto) = await SendRequest<List<SupportUnitDto>>("api/supportUnit/getByListId", ids, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return supportUnitDto;

            else return null;
        }

        public async Task<List<FireTruckDto>> GetFireTruckByListId(List<string> ids, PermissionParam permission)
        {
            var (result, fireTruckDto) = await SendRequest<List<FireTruckDto>>("api/fireTruck/getByListId", ids, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return fireTruckDto;

            else return null;
        }


        public async Task<bool> UpdateDevice(UpdateDeviceInfoDto device)
        {
            var (result, deviceDto) = await SendRequest<bool>("api/fireTruck", device, RestSharp.Method.Put,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return deviceDto;

            else return false;
        }

        public async Task<ApiPaginationWrapperDto> GetConstructionForReportPaging(SearchConstructionDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructions) = await SendRequest<ApiPaginationWrapperDto>("api/construction/searchForReport", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructions;

            else return null;
        }
    }
}
