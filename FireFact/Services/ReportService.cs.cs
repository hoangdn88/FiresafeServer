using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using FireFact.Repositories.Interfaces;
using FireFact.Services.Interfaces;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Common.Entities.DataTransferObjects.Api;
using System.Reflection;

namespace FireFact.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ReportService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<ReportErrorDetailGSM> ReportErrorDetailGSM(SearchReport search)//, OptionalParam<PageParametersDto> paging = null
        {
            List<JigTestResult> jigTestResults = await _repositoryManager.TestResultRepository.GetErrorResult4Report(search);
            if(jigTestResults != null && jigTestResults.Count > 0)
            {
                List<JigTestResult> jigTestResultsError = new();
                List<ErrorInfo> errorInfos = await _repositoryManager.ErrorInfoRepository.GetAllAsync();
                //Add device test error to list
                foreach (var rs in jigTestResults)
                {
                    //Chart
                    DataDictionary dataDictionary = new();

                    if (errorInfos != null && errorInfos.Count > 0)
                    {
                        ErrorInfo errorInfo = errorInfos.Where(x => x.ErrorCode.ToLower() == rs.ErrorCode.ToLower()).FirstOrDefault();
                        //Truong hop co thong tin quan ly loi
                        if (errorInfo != null)
                        {
                            //truong hop co thong tin range
                            if (errorInfo.PassFrom != null || errorInfo.PassTo != null)
                            {
                                bool p = false;
                                if (errorInfo.PassFrom != null && double.TryParse(rs.TestResult.ToString(), out double r) && double.Parse(rs.TestResult.ToString()) >= errorInfo.PassFrom.Value)
                                    p = true;
                                if (errorInfo.PassTo != null && double.TryParse(rs.TestResult.ToString(), out double rr) && double.Parse(rs.TestResult.ToString()) <= errorInfo.PassTo.Value)
                                    p = true;
                                if (!p)
                                    jigTestResultsError.Add(rs);//add device test error to list
                            }
                            else// true/false/string
                            {
                                if (rs.TestResult != null)
                                {
                                    if (bool.TryParse(rs.TestResult.ToString(), out bool r) && !bool.Parse(rs.TestResult.ToString()))
                                        jigTestResultsError.Add(rs);//add device test error to list
                                }
                                else
                                    jigTestResultsError.Add(rs);//add device test error to list
                            }
                        }
                        //Truong hop ko co quan ly loi
                        else
                        {
                            if (rs.TestResult != null)
                            {
                                if (bool.TryParse(rs.TestResult.ToString(), out bool r) && !bool.Parse(rs.TestResult.ToString()))
                                    jigTestResultsError.Add(rs);//add device test error to list
                            }
                            else
                                jigTestResultsError.Add(rs);//add device test error to list
                        }
                    }
                    else
                    {
                        if (rs.TestResult != null)
                        {
                            if (bool.TryParse(rs.TestResult.ToString(), out bool r) && !bool.Parse(rs.TestResult.ToString()))
                                jigTestResultsError.Add(rs);//add device test error to list
                        }
                        else
                            jigTestResultsError.Add(rs);//add device test error to list
                    }
                }

                if(jigTestResultsError.Count > 0)
                {
                    ReportErrorDetailGSM reportErrorDetail = new();
                    //add error device to list
                    reportErrorDetail.DeviceInfoDtos = jigTestResultsError.GroupBy(r => new { imei = r.GsmIMEI, mac = r.MacJIG })//, d = r.DateTest 
                        .Select(rs => new DeviceInfoDto
                        {
                            GsmIMEI = rs.Select(x => x.GsmIMEI).FirstOrDefault(),
                            MacJIG = rs.Select(x => x.MacJIG).FirstOrDefault(),
                            DateTest = rs.Select(x => x.DateTest).LastOrDefault()
                        }).OrderBy(x => x.DateTest).ToList();

                    //Chart
                    reportErrorDetail.ChartErrorDetail = jigTestResultsError.GroupBy(rs => new { day = rs.DateTest.Day, month = rs.DateTest.Month, year = rs.DateTest.Year })
                        .Select(c => new DataDictionary
                        {
                            Key = c.Select(x => x.DateTest).FirstOrDefault().ToString("dd/MM/yyyy"),
                            Value = c.Count()
                        }).OrderBy(x => x.Key).ToList();

                    return reportErrorDetail;
                }
            }
            return null;
        }

        public async Task<DeviceInfoDto> ReportTestResultDetail(string imei)
        {
            List<JigTestResult> jigTestResults = await _repositoryManager.TestResultRepository.GetByImei(imei);
            List<ErrorInfo> errorInfos = await _repositoryManager.ErrorInfoRepository.GetAllAsync();
            if (jigTestResults != null && jigTestResults.Count > 0)
            {
                DeviceInfoDto deviceInfoDto = new();
                deviceInfoDto.GsmIMEI = imei;
                deviceInfoDto.MacJIG = jigTestResults.Select(x=>x.MacJIG).FirstOrDefault();
                deviceInfoDto.DateTest = jigTestResults.Select(x => x.DateTest).LastOrDefault();
                int countPass = 0;
                int countTest = jigTestResults.Count();
                deviceInfoDto.ErrorDetails = new();
                foreach (var rs in jigTestResults)
                {
                    ErrorDetailDto dto = new();
                    dto.ErrorCode = rs.ErrorCode;
                    dto.DateTest = rs.DateTest;
                    if(errorInfos != null && errorInfos.Count > 0)
                    {
                        ErrorInfo errorInfo = errorInfos.Where(x => x.ErrorCode == rs.ErrorCode).FirstOrDefault();
                        if (errorInfo != null)
                        {
                            //truong hop co thong tin range
                            if (errorInfo.PassFrom != null || errorInfo.PassTo != null)
                            {
                                short pf = 0;//default pass from null
                                short pt = 0;//default pass to null
                                if (errorInfo.PassFrom != null && double.TryParse(rs.TestResult.ToString(), out double r))
                                {
                                    if (double.Parse(rs.TestResult.ToString()) >= errorInfo.PassFrom.Value)
                                        pf = 1;//pass
                                    else
                                        pf = 2;//fail
                                }
                                if (errorInfo.PassTo != null && double.TryParse(rs.TestResult.ToString(), out double rr))
                                {
                                    if(double.Parse(rs.TestResult.ToString()) <= errorInfo.PassTo.Value)
                                        pt = 1;//pass
                                    else
                                        pt = 2;//fail
                                }

                                if (pf <= 1 && pt <= 1)
                                {
                                    countPass++;
                                    dto.TestResult = true;
                                }

                            }
                            else// true/false/string
                            {
                                if(rs.TestResult != null)
                                {
                                    //is bool
                                    if (bool.TryParse(rs.TestResult.ToString(), out bool r))
                                    {
                                        if (bool.Parse(rs.TestResult.ToString()))
                                        {
                                            countPass++;
                                            dto.TestResult = true;
                                        }
                                    }
                                    else //string
                                    {
                                        countPass++;
                                        dto.TestResult = true;
                                    }
                                }
                            }
                        }
                        //Truong hop ko co quan ly loi
                        else if(rs.TestResult != null)
                        {
                            //is bool
                            if (bool.TryParse(rs.TestResult.ToString(), out bool r))
                            {
                                if (bool.Parse(rs.TestResult.ToString()))
                                {
                                    countPass++;
                                    dto.TestResult = true;
                                }
                            }
                            else //string
                            {
                                countPass++;
                                dto.TestResult = true;
                            }
                        }
                    }
                    //Truong hop ko co quan ly loi
                    else if (rs.TestResult != null)
                    {
                        //is bool
                        if (bool.TryParse(rs.TestResult.ToString(), out bool r))
                        {
                            if (bool.Parse(rs.TestResult.ToString()))
                            {
                                countPass++;
                                dto.TestResult = true;
                            }
                        }
                        else //string
                        {
                            countPass++;
                            dto.TestResult = true;
                        }
                    }
                    deviceInfoDto.ErrorDetails.Add(dto);
                }
                deviceInfoDto.CountPass = countPass + "/" + countTest;
                if (countPass == countTest)
                    deviceInfoDto.IsPass = true;
                return deviceInfoDto;
            }
            return null;
        }
    
        public async Task<ReportErrorDetailGSM> ReportErrorSummary(SearchReport search)
        {
            List<ErrorInfo> errorInfos = await _repositoryManager.ErrorInfoRepository.GetAllAsync();
            if (errorInfos != null && errorInfos.Count > 0)
            {
                ReportErrorDetailGSM reportErrorDetail = new();
                reportErrorDetail.ChartErrorDetail = new();
                foreach (ErrorInfo errorInfo in errorInfos)
                {
                    string name = "Lỗi " + errorInfo.ErrorCode;
                    search.ErrorCode = errorInfo.ErrorCode;

                    List<JigTestResult> testResults = await _repositoryManager.TestResultRepository.GetErrorResult4Report(search);
                    if(testResults != null && testResults.Count > 0)
                    {
                        int countFail = 0;
                        foreach(JigTestResult rs in testResults)
                        {
                            //truong hop co thong tin range
                            if (errorInfo.PassFrom != null || errorInfo.PassTo != null)
                            {
                                bool p = false;
                                if (errorInfo.PassFrom != null && double.TryParse(rs.TestResult.ToString(), out double r) && double.Parse(rs.TestResult.ToString()) >= errorInfo.PassFrom.Value)
                                    p = true;
                                if (errorInfo.PassTo != null && double.TryParse(rs.TestResult.ToString(), out double rr) && double.Parse(rs.TestResult.ToString()) <= errorInfo.PassTo.Value)
                                    p = true;

                                if (!p)
                                    countFail++;

                            }
                            else// true/false/string
                            {
                                if (rs.TestResult != null)
                                {
                                    //is bool
                                    if (bool.TryParse(rs.TestResult.ToString(), out bool r) && !bool.Parse(rs.TestResult.ToString()))
                                        countFail++;
                                }
                                else
                                    countFail++;
                            }
                        }

                        if(countFail > 0)
                        {
                            DataDictionary dataDictionary = new DataDictionary
                            {
                                Key = name,
                                Value = countFail
                            };
                            reportErrorDetail.ChartErrorDetail.Add(dataDictionary);
                        }
                    }
                }
                if(reportErrorDetail.ChartErrorDetail != null && reportErrorDetail.ChartErrorDetail.Count > 0)
                    return reportErrorDetail;
            }

            return null;
        }
    }
}
