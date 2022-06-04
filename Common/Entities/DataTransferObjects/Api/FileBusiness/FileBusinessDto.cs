using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FileBusinessDto
    {
        [Required]
        public string FileExtension { get; set; }
        [Required]
        public IFormFile UploadedFile { get; set; }
    }
}
