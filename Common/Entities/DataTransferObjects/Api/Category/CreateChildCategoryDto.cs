using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class CreateChildCategoryDto
    {
        public CreateCategoryDto ChildCategory { get; set; }
        public CategoryDto ParentCategory { get; set; }
    }
}
