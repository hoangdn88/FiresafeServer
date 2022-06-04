using Common.Entities.DataTransferObjects.Api.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class DashBoardDto
    {
        public FireFighterDto Mayor { get; set; }// thông tin lãnh đạo tỉnh
        public int? CounstructionCount { set; get; } // tổng số cơ sở công trình
        public int? CounstructionSafeCount { set; get; }// tổng số cơ sở công trình đảm bảo ATTT PCCC
        public int? CounstructionDigitizedCount { set; get; }// tổng số cơ sở công trình đã số hóa
        public int? CounstructionNotDigitizingCount { set; get; }// tổng số cơ sở công trình chưa số hóa
        public int? FireProtectionCount { set; get; } // tổng số vụ cháy
        public int? RescueWorkCount { set; get; } // tổng số vụ CHCN
        public int? FinishWorkCount { set; get; } // tổng số vụ CHCN
        public double? Damage { set; get; } // Thiệt hại
        public int? PcccUnitCount { set; get; } // số đơn vị PCCC chuyên ngành
        public int? FireFighterCount { set; get; } // số cán bộ trực thuộc
        public int? FireTruckCount { set; get; } // số phương tiện PCCC
        public int? WaterPointCount { set; get; } // số điểm lấy nước
        public List<DataDictionary> DeviceInstallData { set; get; } // dữ liệu thiết bị lắp đặt theo tháng
        public List<DataDictionary> ConstructionInstallData { set; get; } // dữ liệu cơ sở lắp đặt theo tháng
        public List<DataDictionary> FireProtectionData { set; get; } // dữ liệu số vụ cháy theo tháng
        public List<DataDictionary> DeadData { set; get; } // dữ liệu số người bị chết theo tháng
        public List<DataDictionary> DamageData { set; get; } // dữ liệu thiệt hại tài sản theo tháng
        public List<DataDictionary> InjuredPersonData { set; get; } // dữ liệu số người bị thương theo tháng
        public List<DataDictionary> SavedPersonData { set; get; } // dữ liệu số người được cứu theo tháng
        public List<ConstructionDto> ConstructionAlarmWrong { set; get; } // danh sách cơ sở cảnh báo sai quá 3 lần, thiết bị không hoạt động
        public List<DataDictionary> ConstructionGrowth { set; get; } // dữ liệu tăng trưởng cơ sở công trình
        public List<DataDictionary> DevicePercentGrowth { set; get; } // dữ liệu tăng trưởng cơ sở công trình
        public List<DataDictionary> DeviceQuantityGrowth { set; get; } // dữ liệu tăng trưởng cơ sở công trình
        public List<DataDictionary> CorrectAlarm { set; get; } // Cảnh báo đúng
        public List<DataDictionary> WrongAlarm { set; get; } // Cảnh báo sai
        public List<object> ConstructionChecking { set; get; } // danh sách hoạt động kiểm tra ATTT PCCC
        public PageParametersDto PageParameters { set; get; }
        public List<string> ConstructionIds { set; get; }
    }
}
