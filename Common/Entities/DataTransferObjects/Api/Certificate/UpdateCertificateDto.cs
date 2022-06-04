using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UpdateCertificateDto : UpdateBase
    {
        public LocationInfoDto Location { set; get; }
        public string ConstructionId { set; get; }
        public DateTime? IssueDate { set; get; } // Ngày cấp
        public string Name { set; get; } // Tên văn bản
        public string Number { set; get; } // Số văn bản
        public string Office { set; get; } // Cơ quan cấp
        public string Note { set; get; } // Ghi chú
        public string FileUrl { set; get; } //Link file đính kèm
    }
}
