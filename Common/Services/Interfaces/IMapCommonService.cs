using Common.Entities.DataTransferObjects.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IMapCommonService
    {
        Task<MapResultDto> GetLocationByCoordinates(CoordinatesDto coordinates);
        Task<MapResultDto> GetLocationByKeyWord(SearchMapByKeyWords search);
        Task<MapResultDto> GetLocationByName(SearchAdd2Geo search);
        Task<MapResultFindRouteDto> FindRoute(SearchRouteMap search);
    }
}
