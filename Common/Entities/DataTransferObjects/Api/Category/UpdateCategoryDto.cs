using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<CategoryDto> CategoryChild { get; set; } // List Category children
    }
}
