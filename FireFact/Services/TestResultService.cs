using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using FireFact.Repositories.Interfaces;
using FireFact.Services.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FireFact.Services
{
    public class TestResultService: ITestResultService
    {
        private readonly IRepositoryManager repositoryManager;

        public TestResultService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<bool> MultiSaveAsync(List<TestResultDto> testResultDtos, CancellationToken cancellationToken = default)
        {
            if (testResultDtos != null && testResultDtos.Count > 0)
            {
                List<JigTestResult> jigTestResults = new();
                foreach(var testResult in testResultDtos)
                {
                    DateTime dt = Common.Utils.Convert.UnixTimeStampToDateTime(testResult.Timestamp);//.AddHours(-7);
                    if (testResult.ErrorResults != null && testResult.ErrorResults.Count > 0)
                    {
                        foreach(var rs in testResult.ErrorResults)
                        {
                            bool del = await DeleteTestResultExist(testResult.GsmIMEI, rs.Key, cancellationToken);
                            if (del)
                            {
                                JigTestResult jigTestResult = new();
                                jigTestResult.Timestamp = testResult.Timestamp;
                                jigTestResult.DateTest = dt;
                                jigTestResult.DeviceType = testResult.DeviceType;
                                jigTestResult.FirmwareVersion = testResult.FirmwareVersion;
                                jigTestResult.HardwardVersion = testResult.HardwardVersion;
                                jigTestResult.MacJIG = testResult.MacJIG;
                                jigTestResult.GsmIMEI = testResult.GsmIMEI;
                                jigTestResult.ErrorCode = rs.Key;
                                jigTestResult.TestResult = rs.Value.ToString();

                                jigTestResults.Add(jigTestResult);
                            }
                        }
                    }
                }

                //save test result
                if (jigTestResults.Count > 0)
                    return await repositoryManager.TestResultRepository.CreateListAsync(x => x.Id, jigTestResults, true, cancellationToken);
            }
            return false;
        }

        /// <summary>
        /// Delete test result if old exist
        /// </summary>
        /// <param name="imei"></param>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        private async Task<bool> DeleteTestResultExist(string imei, string errorcode, CancellationToken cancellationToken)
        {
            JigTestResult testResult = await repositoryManager.TestResultRepository.GetByImeiAndErrorCode(imei, errorcode);
            if(testResult != null)
            {
                testResult.DeleteFlag = true;
                bool del = await repositoryManager.TestResultRepository.UpdateAsync(x => x.Id, testResult, false, cancellationToken);
                if (!del)
                    return false;
            }
            return true;
        }

        public async Task<bool> SaveAsync(TestResultDto testResultDto, CancellationToken cancellationToken = default)
        {
            if(testResultDto != null)
            {
                JigTestResult jigTestResult = testResultDto.Adapt<JigTestResult>();
                //jigTestResult.SendDate = Common.Utils.Convert.UnixTimeStampToDateTime(testResultDto.Timestamp).AddHours(-7);

                return await repositoryManager.TestResultRepository.UpdateAsync(x => x.Id, jigTestResult, true, cancellationToken);
            }
            return false;
        }
    }
}
