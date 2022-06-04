using Common.Entities.DataTransferObjects.Api.Fact;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FireFact.Services.Interfaces
{
    public interface ITestResultService
    {
        Task<bool> SaveAsync(TestResultDto testResultDto, CancellationToken cancellationToken = default);
        Task<bool> MultiSaveAsync(List<TestResultDto> testResultDtos, CancellationToken cancellationToken = default);
        //Task<bool> MultiSaveAsync1(List<TestResultDto> testResultDtos, CancellationToken cancellationToken = default);
    }
}
