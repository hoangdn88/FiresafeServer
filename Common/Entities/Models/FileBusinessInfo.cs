using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class FileBusinessInfo : Base
    {
        public string FileName { get; set; } // Tên file
        public string FilePath { get; set; }
        public string FileData { get; set; }
        public string ObjectId { get; set; } // Id đối tượng chứa file 
        public string ObjectName { get; set; } // Tên đối tượng chứa file 
        public string Description { get; set; } // Mô tả
        public string UserCreatedId { get; set; } // Id người tạo
        public DateTime? CreatedDate { get; set; }// Ngày tạo file
        public string FileUrl { get; set; } // Link chứa file
    }
}
