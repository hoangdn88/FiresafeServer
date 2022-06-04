using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class CategoryInfo : Base
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<CategoryInfo> CategoryChild { get; set; } // List Category children
        public CategoryInfo() : base()
        {
        }
    }
}
