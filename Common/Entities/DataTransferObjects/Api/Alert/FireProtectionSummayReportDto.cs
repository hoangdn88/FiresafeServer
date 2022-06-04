using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api.Alert
{
    public class FireProtectionSummayReportDto
    {
        public LocationInfo Location { get; set; }
        public int? FireProtectionSum { get; set; } // tổng số vụ cháy
        public int? CorrectAlertCount { get; set; } // cảnh báo đúng
        public int? InCorrectAlertCount { get; set; } // cảnh báo sai
        public int? PeopleAlertCount { get; set; }//người dân báo cháy
        public int? DeviceAlertCount { get; set; }//thiết bị báo cháy
        public int? COYReasonCount { get; set; } //Lỗi cố ý
        public int? VOYReasonCount { get; set; } //Lỗi vô ý
        public int? OtherReasonCount { get; set; } //Lỗi khác
        public int? ResidentialCount { get; set; } //trong khu dân cư
        public int? PublicPlaceCount { get; set; } // Nơi công cộng
        public int? OfficeCount { get; set; } //trong cơ quan doanh nghiệp
        public int? ForestFiresCount { get; set; } // Cháy rừng
        public int? WarehouseWeaponsCount { get; set; } // Cháy kho chứa vũ khí
        public int? HightRiseBuildingCount { get; set; } // Cháy nhà cao tầng
        public int? TransportCount { get; set; } // Cháy phương tiện giao thông vận tải

        public double? CorrectAlertPercent { get; set; } // cảnh báo đúng
        public double? InCorrectAlertPercent { get; set; } // cảnh báo sai
        public double? PeopleAlertPercent { get; set; }//người dân báo cháy
        public double? DeviceAlertPercent { get; set; }//thiết bị báo cháy
        public double? COYReasonPercent { get; set; } //Lỗi cố ý
        public double? VOYReasonPercent { get; set; } //Lỗi vô ý
        public double? OtherReasonPercent { get; set; } //Lỗi khác
        public double? ResidentialPercent { get; set; } //trong khu dân cư
        public double? PublicPlacePercent { get; set; } // Nơi công cộng
        public double? OfficePercent { get; set; } //trong cơ quan doanh nghiệp
        public double? ForestFiresPercent { get; set; } // Cháy rừng
        public double? WarehouseWeaponsPercent { get; set; } // Cháy kho chứa vũ khí
        public double? HightRiseBuildingPercent { get; set; } // Cháy nhà cao tầng
        public double? TransportPercent { get; set; } // Cháy phương tiện giao thông vận tải

        public List<FireProtectionSummayReportDto> Children { get; set; }

    }
}
