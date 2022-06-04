using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Device;
using Common.Entities.Models;
using Common.Entities.Models.Device;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IFireInventoryService
    {
        Task<DeviceInfoDto> GetDeviceByImei(string imei, PermissionParam permission);
        
        Task<CustomerInfo> GetCustomerById(string id, PermissionParam permission);
        Task<UserDto> GetUserByName(string userName, PermissionParam permission);
        Task<List<CustomerInfo>> GetCustomerAndChilds(string customerId, PermissionParam permission);

        Task<string> CreateConstruction(ConstructionForCreationDto construction, PermissionParam permission);
        Task<ConstructionDto> GetConstructionById(string id, PermissionParam permission);
        Task<List<ConstructionDto>> GetConstructionByName(string name, PermissionParam permission);
        Task<List<ConstructionDto>> GetConstructionByLocation(LocationInfo location, PermissionParam permission);
        Task<List<ConstructionDto>> GetConstructionForReport(SearchConstructionDto search, PermissionParam permission);
        Task<List<ConstructionDto>> GetAllConstructionById(List<string> construction, PermissionParam permission);
        Task<List<ConstructionDto>> GetConstructionByCustomerId(string id, PermissionParam permission);
        //Task<List<ConstructionDto>> GetAllConstruction();
        Task<List<DeviceInfoDto>> GetDeviceByConstructions(List<string> constructionIds, PermissionParam permission);
        Task<StatisticDto> GetStatisticByConstructions(List<string> constructionIds, PermissionParam permission);
        
        Task<PcccUnitInfo> GetPcccUnitById(string id, PermissionParam permission);
        Task<List<PcccUnitDto>> SearchPcccUnitByLocation(LocationInfoDto location, PermissionParam permission);
        Task<List<PcccUnitInfo>> GetAllPcccUnitById(List<string> ids, PermissionParam permission);
        Task<List<PcccUnitInfo>> GetAllPcccUnit(PermissionParam permission);

        Task<List<SupportUnitDto>> GetSupportUnitsByListId(List<string> ids, PermissionParam permission);
        Task<List<FireTruckDto>> GetFireTruckByListId(List<string> ids, PermissionParam permission);
        Task<List<SupportUnitDto>> GetSupportUnitsByPcccUnitId(string pcccUnitId, PermissionParam permission);
        Task<List<WaterPointDto>> GetWaterPointsByPcccUnitId(string pcccUnitId, PermissionParam permission);
        Task<List<FireTruckDto>> GetFireTrucksByPcccUnitId(string pcccUnitId, PermissionParam permission);

        Task<FireTruckDto> GetFireTruckById(string id, PermissionParam permission);
        Task<List<SupportUnitDto>> GetSupportUnitsByRadius(double longitude, double latitude, double radius, PermissionParam permission);
        Task<List<WaterPointDto>> GetWaterPointsByRadius(double longitude, double latitude, double radius, PermissionParam permission);
        Task<List<ReportFireTruckInfo>> CountFireTruckStatusAsync(SearchDataReportFireTruckDto search, PermissionParam permission);
        Task<List<FireTruckDto>> GetDataFireTruckAsync(SearchDataReportFireTruckDto search, PermissionParam permission);

        Task<List<ConstructionDto>> GetAllConstruction(PermissionParam permission);
        //Task<List<ConstructionDto>> GetAllByLocationAndCustomer(List<LocationInfo> locationPermissions = null, List<UserPermission> userPermissions = null, string customerId = null);

        Task<List<WaterPointDto>> GetWaterPointsByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission);
        Task<List<FireTruckDto>> GetFireTrucksByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission);
        Task<List<FireFighterDto>> GetFireFighterByPcccUnitId(List<string> pcccUnitIds, PermissionParam permission);
        Task<FireFighterDto> GetManagerByCityId(string cityId, PermissionParam permission);
        Task<bool> UpdateFireTruck(FireTruckForUpdateDto fireTruck, PermissionParam permission);
        Task<DashBoardDto> GetDataDashBoard(LocationInfoDto location, PermissionParam permission);
        Task<SupportUnitDto> GetSupportUnitsById(string supportId, PermissionParam permission);
        Task<List<FireFighterDto>> SearchFireFighter(SearchByForPcccUnitScreen search, PermissionParam permission);
        Task<List<PcccUnitDto>> SearchPcccUnit(SearchPcccUnitDto search, PermissionParam permission);
        Task<bool> UpdateDevice(UpdateDeviceInfoDto device);

        Task<ApiPaginationWrapperDto> GetConstructionForReportPaging(SearchConstructionDto searc, PermissionParam permission);
        Task<ApiPaginationWrapperDto> GetDataFireTruckPagingAsync(SearchDataReportFireTruckDto search, PermissionParam permission);

    }
}
