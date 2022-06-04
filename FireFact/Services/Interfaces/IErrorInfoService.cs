using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using Microsoft.AspNetCore.Http;

namespace FireFact.Services.Interfaces
{
    public interface IErrorInfoService
    {
        Task<bool> InsertAsync(ErrorInfoDto errorInfoDto, string creator, CancellationToken cancellationToken = default, string id = null);
        Task<bool> UpdateAsync(UpdateErrorInfoDto errorInfoDto, string creator, CancellationToken cancellationToken = default);
        Task<List<ErrorInforResponseDto>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null);
        Task<bool> DeleteAsync(string id, string creator, CancellationToken cancellationToken = default);
        Task<bool> IsExistCode(string code, string id = null);
        Task<ErrorInforResponseDto> GetById(string id, CancellationToken cancellationToken = default);
        Task<ErrorInfo> GetByCode(string code);
        Task<string> SendFileToS3(IFormFile uploadedFile, string id);
    }
}
