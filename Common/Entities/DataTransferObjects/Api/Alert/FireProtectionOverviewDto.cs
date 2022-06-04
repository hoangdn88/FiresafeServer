using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api.Alert
{
    public class FireProtectionOverviewDto
    {
        public string Id { set; get; } // Mã địa điểm chữa cháy
        public ConstructionDto Construction { set; get; } // Cơ sở công trình        
    }
}
