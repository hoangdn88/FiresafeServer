using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.DataTransferObjects.Api.Fact;
using Common.Entities.Models.Fact;
using FireFact.Repositories.Interfaces;
using FireFact.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FireFact.Services
{
    public class ErrorInfoService : Common.Services.Base, IErrorInfoService
    {
        private string accessKey => Configuration.GetValue<string>("AWSUpFile:AccessKeyId");
        private string secretKey => Configuration.GetValue<string>("AWSUpFile:SecretAccessKey");
        private string baseUrl => Configuration.GetValue<string>("AWSUpFile:BaseUrl");
        private string serviceUrl => Configuration.GetValue<string>("AWSUpFile:ServiceUrl");
        private string bucketName => Configuration.GetValue<string>("AWSUpFile:BucketName");

        private readonly IRepositoryManager _repositoryManager;
        public ErrorInfoService(IRepositoryManager repositoryManager, IConfiguration configuration) : base(configuration)
        {
            this._repositoryManager = repositoryManager;
        }
        public async Task<bool> DeleteAsync(string id, string creator, CancellationToken cancellationToken = default)
        {
            ErrorInfo errorInfo = await _repositoryManager.ErrorInfoRepository.GetByIndexAsync(x => x.Id, id, cancellationToken);
            if (errorInfo != null)
            {
                errorInfo.DeleteFlag = true;
                errorInfo.CreateTime = System.DateTime.Now;//use for time update
                errorInfo.Creator = creator;
                return await _repositoryManager.ErrorInfoRepository.UpdateAsync(x => x.Id, errorInfo, false, cancellationToken);
            }
            return false;
        }

        public async Task<List<ErrorInforResponseDto>> GetAllByCode(string code, OptionalParam<PageParametersDto> paging = null)
        {
            var errorInfo = await _repositoryManager.ErrorInfoRepository.GetAllByCode(code, paging);
            if (errorInfo != null)
                return errorInfo.Adapt<List<ErrorInforResponseDto>>();
            return null;
        }

        public async Task<ErrorInforResponseDto> GetById(string id, CancellationToken cancellationToken = default)
        {
            ErrorInfo errorInfo = await _repositoryManager.ErrorInfoRepository.GetByIndexAsync(x => x.Id, id, cancellationToken);
            if (errorInfo != null)
                return errorInfo.Adapt<ErrorInforResponseDto>();
            return null;
        }

        public async Task<ErrorInfo> GetByCode(string code)
        {
            return await _repositoryManager.ErrorInfoRepository.GetByCode(code);
        }

        public async Task<bool> InsertAsync(ErrorInfoDto errorInfoDto, string creator, CancellationToken cancellationToken = default, string id = null)
        {
            ErrorInfo errorInfo = errorInfoDto.Adapt<ErrorInfo>();
            errorInfo.CreateTime = System.DateTime.Now;
            errorInfo.Creator = creator;
            errorInfo.ErrorCode = errorInfo.ErrorCode.Trim();
            if (!string.IsNullOrEmpty(id))
                errorInfo.Id = id;

            return await _repositoryManager.ErrorInfoRepository.UpdateAsync(x => x.ErrorCode, errorInfo, true, cancellationToken);
        }

        /// <summary>
        /// Check exist code
        /// Use id for edit
        /// </summary>
        /// <param name="code"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistCode(string code, string id = null)
        {
            ErrorInfo errorInfo = await _repositoryManager.ErrorInfoRepository.GetByCode(code);
            if (errorInfo != null)
            {
                if(!string.IsNullOrEmpty(id) && errorInfo.Id == id)
                    return false;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(UpdateErrorInfoDto errorInfoDto, string creator, CancellationToken cancellationToken = default)
        {
            ErrorInfo errorInfo = errorInfoDto.Adapt<ErrorInfo>();
            errorInfo.CreateTime = System.DateTime.Now;//time for update
            errorInfo.Creator = creator;
            errorInfo.ErrorCode = errorInfo.ErrorCode.Trim();

            return await _repositoryManager.ErrorInfoRepository.UpdateAsync(x => x.Id, errorInfo, false, cancellationToken);
        }

        public async Task<string> SendFileToS3(IFormFile uploadedFile, string id)
        {
            try
            {
                string fileExtension = System.IO.Path.GetExtension(uploadedFile.FileName);
                var inputStreamFile = uploadedFile.OpenReadStream();

                var config = new AmazonS3Config
                {
                    AuthenticationRegion = RegionEndpoint.USEast1.SystemName,
                    ServiceURL = serviceUrl,
                    ForcePathStyle = true
                };

                IAmazonS3 client = new AmazonS3Client(accessKey, secretKey, config);

                TransferUtility utility = new TransferUtility(client);
                TransferUtilityUploadRequest request = new();

                request.BucketName = bucketName;
                request.Key = id; //Guid.NewGuid().ToString();
                if (!string.IsNullOrEmpty(fileExtension))
                    request.Key += "_" + uploadedFile.FileName;// + "." + fileExtension; //file name up in S3  

                request.InputStream = inputStreamFile;
                utility.Upload(request); //commensing the transfer  

                //await CreateAsync(fileBusiness.Adapt<CreateFileBusinessDto>());

                return $"{baseUrl}/{bucketName}/{request.Key}";
            }
            catch (Exception)
            {
                return null;
            }

        }

        public override Exception CreateException(string message)
        {
            throw new NotImplementedException();
        }
    }
}
