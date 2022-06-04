using Common.Entities.DataTransferObjects.Api.Fact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireFact.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportErrorDetailGSM> ReportErrorDetailGSM(SearchReport search);//, OptionalParam<PageParametersDto> paging = null
        Task<DeviceInfoDto> ReportTestResultDetail(string imei);
        Task<ReportErrorDetailGSM> ReportErrorSummary(SearchReport search);
    }
}
