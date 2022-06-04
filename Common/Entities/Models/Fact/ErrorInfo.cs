using Common.Entities.DataTransferObjects.Api;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Models.Fact
{
    public class ErrorInfo : Base
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public double? PassFrom { get; set; }
        public double? PassTo { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        //public List<string> FileUrl { get; set; }
        public List<FileNameAndUrl> fileUpload { get; set; }
    }
}
