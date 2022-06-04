using Common.Entities.DataTransferObjects.Api;
using Common.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class MapService : Base, IMapCommonService
    {
        private string Key;
        public MapService(IConfiguration configuration) : base(configuration)
        {
            BaseUrl = Configuration.GetValue<string>("MapServer:BaseUrl");
            Key = Configuration.GetValue<string>("MapServer:Key");
            if (BaseUrl.EndsWith('/') == false) BaseUrl += '/';
        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<MapResultFindRouteDto> FindRoute(SearchRouteMap search)
        {
            var (result, data) = await SendRequest<object>("FRoute", search, RestSharp.Method.Post,
            new Dictionary<string, string> { { "keys", Key } });

            if (result == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MapResultFindRouteDto>(data.ToString());

            else return null;
        }

        public async Task<MapResultDto> GetLocationByCoordinates(CoordinatesDto coordinates)
        {
            var (result, data) = await SendRequest<object>("Geo2Add", coordinates, RestSharp.Method.Post,
            new Dictionary<string, string> { { "keys", Key } });

            if (result == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MapResultDto>(data.ToString());

            else return null;
        }

        public async Task<MapResultDto> GetLocationByKeyWord(SearchMapByKeyWords search)
        {
            var (result, data) = await SendRequest<object>("Search", search, RestSharp.Method.Post,
            new Dictionary<string, string> { { "keys", Key } });

            if (result == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MapResultDto>(data.ToString());

            else return null;
        }

        public async Task<MapResultDto> GetLocationByName(SearchAdd2Geo search)
        {
            var (result, data) = await SendRequest<object>("Add2Geo", search, RestSharp.Method.Post,
            new Dictionary<string, string> { { "keys", Key } });

            if (result == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MapResultDto>(data.ToString());

            else return null;
        }
    }
}
