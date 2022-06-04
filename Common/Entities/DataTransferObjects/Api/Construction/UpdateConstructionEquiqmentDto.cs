using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Construction
{
    public class UpdateConstructionEquiqmentDto : UpdateBase
    {
        public string Name { get; set; }
        public string Type { get; set; } // Loại
        public string TypeDetail { get; set; }
        public string Count { get; set; }
        public string Status { get; set; } // Trạng thái
        public string WokingStatus { get; set; } // Trạng thái hoạt động
        public string InstallLocation { get; set; } // vị trí lắp đặt
        public string Action { get; set; } // Hành động
        public string ConstructionId { get; set; }
    }
}
