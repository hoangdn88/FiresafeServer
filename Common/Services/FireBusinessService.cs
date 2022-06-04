using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Map;
using Common.Entities.DataTransferObjects.Api.Notice;
using Common.Entities.Models;
using Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FireBusinessService : Base, IFireBusinessService
    {
        public FireBusinessService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("FireBusinessServer:BaseUrl");
            if (BaseUrl?.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ConstructionCheckingDto>> GetConstructionCheckingByConstruction(List<string> constructionIds, PermissionParam permission)
        {
            var (result, constructionCheckings) = await SendRequest<List<ConstructionCheckingDto>>("api/constructionChecking/getAllByConstructionIds", constructionIds, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructionCheckings;

            else return null;
        }

        public async Task<List<PropagateInfo>> GetPropagateByConstruction(List<string> constructionIds, PermissionParam permission)
        {
            var (result, propagetInfo) = await SendRequest<List<PropagateInfo>>("api/propagate/getByListConstruction", constructionIds, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return propagetInfo;

            else return null;
        }

        public async Task<List<PlanningInfo>> GetTrainningByConstruction(List<string> constructionIds, PermissionParam permission)
        {
            var (result, planningInfo) = await SendRequest<List<PlanningInfo>>("api/planningInfo/getByListConstruction", constructionIds, RestSharp.Method.Post,
    new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return planningInfo;

            else return null;
        }

        public async Task<List<ViolationInfo>> GetViolationByConstruction(List<string> constructionIds, PermissionParam permission)
        {
            var (result, planningInfo) = await SendRequest<List<ViolationInfo>>("api/violation/getByListConstruction", constructionIds, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return planningInfo;

            else return null;
        }

        public async Task<List<ConstructionCheckingDto>> GetConstructionCheckingForReport(SearchConstructionCheckingDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructionCheckings) = await SendRequest<List<ConstructionCheckingDto>>("api/constructionChecking/getDataForReport", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
            { 
                return constructionCheckings;
            }

            else return null;
        }

        public async Task<ApiPaginationWrapperDto> GetConstructionCheckingForDashBoard(SearchConstructionCheckingDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructionCheckings) = await SendRequest<ApiPaginationWrapperDto>("api/constructionChecking/getDataForReport", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission?.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
            {
                return constructionCheckings;
            }

            else return null;
        }

        public async Task<List<ReportConstructionCheckingInfo>> CountConstructionCheckingForReport(SearchConstructionCheckingDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructionCheckings) = await SendRequest<List<ReportConstructionCheckingInfo>>("api/constructionChecking/countDataForReport", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructionCheckings;

            else return null;
        }

        public async Task<List<RescueWorkInfoDto>> GetAllRescueWork(PermissionParam permission)
        {
            var (result, rescueWorkInfo) = await SendRequest<List<RescueWorkInfoDto>>("api/rescueWork", string.Empty, RestSharp.Method.Get,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return rescueWorkInfo;

            else return null;
        }

        public async Task<List<RescueWorkInfoDto>> GetRescueWorkByCityId(string cityId, PermissionParam permission)
        {
            var location = new LocationInfoDto { CityId = cityId };
            var (result, rescueWorkInfo) = await SendRequest<List<RescueWorkInfoDto>>("api/rescueWork/getDataByLocation", location, RestSharp.Method.Post,
             new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return rescueWorkInfo;

            else return null;
        }

        public async Task<int> CountConstructionCheckingGuaranteed(SearchConstructionCheckingDto search, PermissionParam permission)
        {
            if (search == null) search = new();
            var (result, constructionCheckings) = await SendRequest<int>("api/constructionChecking/getCountDataForDashBoard", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) } });

            if (result == System.Net.HttpStatusCode.OK)
                return constructionCheckings;

            else return 0;
        }

        public async Task<DashBoardDto> GetDataDashBoard(LocationInfoDto location, PermissionParam permission)
        {
            var (result, data) = await SendRequest<DashBoardDto>("api/DashBoard/getData", location, RestSharp.Method.Post,
                 new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission?.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return null;
        }

        public async Task<bool> CreateNotice(CreateNoticeDto noticeDto)
        {
            var (result, data) = await SendRequest<bool>("api/notice", noticeDto, RestSharp.Method.Post,
            new Dictionary<string, string> { { "Authorization", GenerateToken() }});

            if (result == System.Net.HttpStatusCode.OK)
                return true;

            else return false;
        }

        public async Task<List<MapDto>> SearchMap(SearchMapDto search, PermissionParam permission)
        {
            var (result, data) = await SendRequest<List<MapDto>>("api/Map/search", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken(permission) }, { "PageOption", JsonConvert.SerializeObject(permission?.Paging?.Value) } });

            if (result == System.Net.HttpStatusCode.OK)
                return data;

            else return data;
        }

        public async Task<long> CountNoticeUnread(SearchNoticeDto search)
        {
            if (search == null) search = new();
            var (result, notice) = await SendRequest<long>("api/notice/countUnread", search, RestSharp.Method.Post,
                new Dictionary<string, string> { { "Authorization", GenerateToken() } });

            if (result == System.Net.HttpStatusCode.OK)
                return notice;

            else return 0;
        }
    }
}
