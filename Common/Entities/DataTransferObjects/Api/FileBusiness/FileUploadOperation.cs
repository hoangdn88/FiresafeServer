using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.FileBusiness
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isFileUploadOperation =
            context.MethodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(FileContentType));

            if (!isFileUploadOperation) return;

            operation.Parameters.Clear();

            var uploadFileMediaType = new OpenApiMediaType()
            {
                Schema = new OpenApiSchema()
                {
                    Type = "object",
                    Properties =
                {
                    ["uploadedFile"] = new OpenApiSchema()
                    {
                        Description = "Upload File",
                        Type = "file",
                        Format = "formData"
                    }
                },
                    Required = new HashSet<string>() { "uploadedFile" }
                }
            };

            operation.RequestBody = new OpenApiRequestBody
            {
                Content = { ["multipart/form-data"] = uploadFileMediaType }
                
            };
        }
        [AttributeUsage(AttributeTargets.Method)]
        public class FileContentType : Attribute
        {

        }
    }



}
