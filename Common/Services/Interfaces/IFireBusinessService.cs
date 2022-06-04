using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Map;
using Common.Entities.DataTransferObjects.Api.Notice;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IFireBusinessService
    {
        Task<List<ConstructionCheckingDto>> GetConstructionCheckingByConstruction(List<string> constructionIds, PermissionParam permission);
        Task<List<PlanningInfo>> GetTrainningByConstruction(List<string> constructionIds, PermissionParam permission);
        Task<List<ViolationInfo>> GetViolationByConstruction(List<string> constructionIds, PermissionParam permission);
        Task<List<PropagateInfo>> GetPropagateByConstruction(List<string> constructionIds, PermissionParam permission);
        Task<List<RescueWorkInfoDto>> GetAllRescueWork(PermissionParam permission);
        Task<List<RescueWorkInfoDto>> GetRescueWorkByCityId(string cityId, PermissionParam permission);
        Task<List<ConstructionCheckingDto>> GetConstructionCheckingForReport(SearchConstructionCheckingDto search, PermissionParam permission);
        Task<List<ReportConstructionCheckingInfo>> CountConstructionCheckingForReport(SearchConstructionCheckingDto search, PermissionParam permission);
        Task<ApiPaginationWrapperDto> GetConstructionCheckingForDashBoard(SearchConstructionCheckingDto search, PermissionParam permission);
        Task<int> CountConstructionCheckingGuaranteed(SearchConstructionCheckingDto search, PermissionParam permission);
        Task<DashBoardDto> GetDataDashBoard(LocationInfoDto location, PermissionParam permission);
        Task<bool> CreateNotice(CreateNoticeDto noticeDto);
        Task<List<MapDto>> SearchMap(SearchMapDto search, PermissionParam permission);
        Task<long> CountNoticeUnread(SearchNoticeDto search);
    }
}
