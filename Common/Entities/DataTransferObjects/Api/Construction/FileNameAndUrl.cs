using Common.Entities.Enum;
using Common.Entities.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FileNameAndUrl 
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
