using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Fact
{
    public class ErrorInfoDto
    {
        [Required(ErrorMessage = "Mã lỗi không được để trống!")]
        [JsonPropertyName("Code")]
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public double? PassFrom { get; set; }
        public double? PassTo { get; set; }
        //public List<string> FileUrl { get; set; }
        public List<FileNameAndUrl> fileUpload { get; set; }
        //public List<IFormFile> UploadedFile { get; set; }
    }

    public class ErrorInforResponseDto : UpdateBase
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public double? PassFrom { get; set; }
        public double? PassTo { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public List<FileNameAndUrl> fileUpload { get; set; }
    }
}
