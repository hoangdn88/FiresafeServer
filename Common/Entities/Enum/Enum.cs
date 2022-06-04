using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OwnerType
    {

        [Description("Cá nhân")]
        [EnumMember(Value = "0")]
        CA_NHAN,
        [Description("Tổ chức")]
        [EnumMember(Value = "1")]
        TO_CHUC
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ManageLevel
    {
        [Description("Trung Ương")]
        TRUNG_UONG = 0,
        [Description("Tỉnh, Thành phố")]
        TINH_THANH_PHO = 1,
        [Description("Quận, Huyện")]
        QUAN_HUYEN = 2,
        [Description("Xã, Phường")]
        XA_PHUONG = 3
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ActivityType
    {
        [Description("Sản xuất")]
        SAN_XUAT = 0,
        [Description("Kinh doanh dịch vụ")]
        KINH_DOANH_DICH_VU = 1,
        [Description("Hành chính")]
        HANH_CHINH = 2
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EconomicSectors
    {
        [Description("Nhà nước")]
        NHA_NUOC = 0,
        [Description("Tập thể")]
        TAP_THE = 1,
        [Description("Tư nhân")]
        TU_NHAN = 2,
        [Description("Tư bản nhà nước")]
        TU_BAN_NHA_NUOC = 3,
        [Description("Vốn đầu tư nước ngoài")]
        VON_DAU_TU_NUOC_NGOAI = 4
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvestmentForm
    {
        [Description("Trong nước")]
        TRONG_NUOC = 0,
        [Description("Nước ngoài")]
        NUOC_NGOAI = 1,
        [Description("Liên doanh với nước ngoài")]
        LIEN_DOANH_NUOC_NGOAI = 2
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FireInsurance
    {
        [Description("Có - Đã Mua")]
        CO_DA_MUA = 0,
        [Description("Có - Chưa Mua")]
        CO_CHUA_MUA = 1,
        [Description("Không - Có Mua")]
        KHONG_CO_MUA = 2,
        [Description("Không - Không Mua")]
        KHONG_KHONG_MUA = 3
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PositionType
    {
        [Description("Nhân viên")]
        NHAN_VIEN = 0,
        [Description("Phó ban")]
        PHO_BAN = 1,
        [Description("Trưởng ban")]
        TRUONG_BAN = 2,
        [Description("Phó phòng")]
        PHO_PHONG = 3,
        [Description("Trưởng phòng")]
        TRUONG_PHONG = 4,
        [Description("Phó giám đôc")]
        PHO_GIAM_DOC = 5,
        [Description("Giám đôc")]
        GIAM_DOC = 6
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RankType
    {
        [Description("Chiến sĩ")]
        CHIEN_SI = 0,
        [Description("Hạ sĩ")]
        HA_SI = 1,
        [Description("Trung sĩ")]
        TRUNG_SI = 2,
        [Description("Thượng sĩ")]
        THUONG_SI = 3,
        [Description("Thiếu úy")]
        THIEU_UY = 4,
        [Description("Trung úy")]
        TRUNG_UY = 5,
        [Description("Thượng úy")]
        THUONG_UY = 6,
        [Description("Đại úy")]
        DAI_UY = 7,
        [Description("Thiếu tá")]
        THIEU_TA = 8,
        [Description("Trung tá")]
        TRUNG_TA = 9,
        [Description("Thượng tá")]
        THUONG_TA = 10,
        [Description("Đại tá")]
        DAI_TA = 11,
        [Description("Thiếu tướng")]
        THIEU_TUONG = 12,
        [Description("Trung tướng")]
        TRUNG_TUONG = 13,
        [Description("Thượng tướng")]
        THUONG_TUONG = 14,
        [Description("Đại tướng")]
        DAI_TUONG = 15
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FireTruckType
    {
        [Description("Xe 5m3")]
        XE_5M3 = 0,
        [Description("Xe 3m3")]
        XE_3M3 = 1,
        [Description("Xe Thang")]
        XE_THANG = 2,
        [Description("Xe Bơm")]
        XE_BOM = 3,
        [Description("Xe Máy")]
        XE_MAY = 4,
        [Description("Xe chở bôt chữa cháy")]
        XE_CHO_BOT_CHUA_CHAY = 5
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnderType
    {
        [Description("Quận huyện")]
        QUAN_HUYEN = 0,
        [Description("PC07")]
        PC07 = 1,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PcccUnitType
    {
        [Description("Đơn vị hành chính")]
        DON_VI_HANH_CHINH = 0,
        [Description("Đơn vị nghiệp vụ")]
        DON_VI_NGHIEP_VU = 1
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DutyType
    {
        [Description("Trực chỉ huy")]
        TRUC_CHI_HUY = 0,
        [Description("Trực thông tin")]
        TRUC_THONG_TIN = 1,
        [Description("Trực ban")]
        TRUC_BAN = 2,
        [Description("Trực kiểm tra")]
        TRUC_KIEM_TRA = 3
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SupportUnitType
    {
        [Description("Bệnh viện")]
        BENH_VIEN = 0,
        [Description("Điện lực")]
        DIEN_LUC = 1,
        [Description("Quân đội")]
        QUAN_DOI = 2,
        [Description("Dân phòng")]
        DAN_PHONG = 3,
        [Description("Lực lượng cháy nổ tại chỗ")]
        LUC_LUONG_CHUA_CHAY_TAI_CHO = 4,
        [Description("Công an")]
        CONG_AN = 5
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EvaluateType
    {

        [Description("Đảm báo yêu cầu PCCC")]
        [EnumMember(Value = "0")]
        DAM_BAO,
        [Description("Chưa đảm bảo")]
        [EnumMember(Value = "1")]
        CHUA_DAM_BAO
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CheckStatus
    {

        [Description("Hoàn thành kiểm tra")]
        [EnumMember(Value = "0")]
        HOAN_THANH,
        [Description("Chưa bắt đầu kiểm tra")]
        [EnumMember(Value = "1")]
        CHUA_BAT_DAU,
        [Description("Đang kiểm tra")]
        [EnumMember(Value = "2")]
        DANG_KIEM_TRA
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BehaviourGroup
    {

        [Description("Hành vi vi phạm trong việc ban hành, phổ biến và tổ chức thực hiện quy định, nội quy về phòng cháy và chữa cháy")]
        [EnumMember(Value = "0")]
        VI_PHAM_BAN_HANH,
        [Description("Hành vi vi phạm quy định về kiểm tra an toàn phòng cháy và chữa cháy")]
        [EnumMember(Value = "1")]
        VI_PHAM_QUY_DINH_KIEM_TRA,
        [Description("Hành vi vi phạm về hồ sơ quản lý công tác an toàn phòng cháy và chữa cháy")]
        [EnumMember(Value = "2")]
        VI_PHAM_HO_SO,
        [Description("Hành vi vi phạm quy định về phòng cháy và chữa cháy trong sản xuất kinh doanh chất, hàng nguy hiểm về cháy nổ")]
        [EnumMember(Value = "3")]
        VI_PHAM_QUY_DINH_PCCC
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DutyDataType
    {
        TRUC_CHI_HUY = 0,
        TRUC_THONG_TIN = 1,
        TRUC_BAN = 2,
        TRUC_KIEM_TRA = 3
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExplosionType
    {
        CHAY = 0,
        NO = 1
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Area
    {
        [Description("Khu dân cư")]
        KHU_DAN_CU = 0,
        [Description("Cơ quan, doanh nghiệp")]
        CO_QUAN_DOANH_NGHIEP = 1,
        [Description("Khu công cộng")]
        NOI_CONG_CONG = 2,
        [Description("Khu Rừng núi")]
        CHAY_RUNG = 3,
        [Description("Kho vũ khí")]
        KHO_VU_KHI = 4,
        [Description("Nhà cao tầng")]
        NHA_CAO_TANG = 5,
        [Description("Phương tiện GTVT")]
        PHUONG_TIEN_GTVT = 6

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FireReason
    {
        [Description("Cố ý")]
        CO_Y = 0,
        [Description("Vô ý")]
        VO_Y = 1,
        [Description("Lỗi khách quan khác")]
        LOI_KHACH_QUAN = 2,
        [Description("Nghi khủng bố, phá hoại")]
        KHUNG_BO_PHA_HOAI = 3
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WorkingStatus
    {
        [Description("Tốt")]
        TOT = 0,
        [Description("Kém")]
        KEM = 1,
        [Description("Cần sửa chữa")]
        CAN_SUA_CHUA = 2,
        [Description("Cần thay thế")]
        CAN_THAY_THE = 3
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IndustryField
    {
        [Description("Công ty sản xuất")]
        CONG_TY_SAN_XUAT = 0,
        [Description("Báo chí, bưu chính")]
        BAO_CHI = 1,
        [Description("Bệnh viện, cơ sở y tế")]
        BENH_VIEN = 2,
        [Description("Chợ")]
        CHO = 3,
        [Description("Cơ sở dệt may, da, giầy")]
        DET_MAY = 4,
        [Description("Cơ sở in ấn")]
        IN_AN = 5,
        [Description("Cơ sở nghiên cứu khoa học")]
        NGHIEN_CUU = 6,
        [Description("Điện lưới")]
        DIEN_LUOI = 7,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SensorType
    {
        CAM_BIEN_KHOI = 0,
        CAM_BIEN_NHIET = 1,
        CAM_BIEN_KHOI_NHIET = 2,
        CHUA_XAC_DINH,
        CHUONG_DEN
    }

    public enum FireBaseDataType
    {
        START_FIRE_ALERT = 0,
        END_FIRE_ALERT = 1
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserActive
    {
        ACTIVE = 1,
        INACTIVE = 2
    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AvailabilityStatus
    {
        [Description("Sẵn sàng")]
        AVAILABLE = 0,
        [Description("Không sẵn sàng")]
        NOT_AVAILABLE = 1
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeviceStatus
    {
        ON = 0,
        OFF = 1,
        HOAT_DONG_LOI = 2
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BatteryStatus
    {
        ENOUGH = 0,
        LOW = 1
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SolvingStatus
    {
        DA_XU_LY = 0,
        CHUA_XU_LY = 1
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PhoneNumberType
    {
        CHU_CO_SO_CONG_TRINH = 0,
        NGUOI_XAC_NHAN = 1,
        NGUOI_BACKUP = 2,
        NGUOI_BAO =3
    }
    public enum HeatLevel
    {
        THAP = 0,
        TRUNG_BINH,
        KHA,
        CAO,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SuspensionType
    {
        CANH_CAO = 0,
        PHAT_TIEN,
        TAM_DINH_CHI,
        DINH_CHI_VINH_VIEN,
        KHAC

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {
        CNTT_SYS = 1, //Cán bộ CNTT SYS
        CB_114 = 2,//Cán bộ 114
        CB_THAM_MUU = 3,//Cán bộ tham mưu
        CB_HAU_CAN_KY_THUAT = 4,//Cán bộ hậu cần kỹ thuật
        CB_DIA_BAN = 5,//Cán bộ địa bàn
        CB_DOI_CHUA_CHAY = 6,//Cán bộ đội chữa cháy
        CB_THU_THAP_DU_LIEU = 7,//Cán bộ thu thập dữ liệu
        LANH_DAO = 8,//Lãnh đạo
        CHU_CSCT = 9,//Chủ cơ sở Công trình
        LUC_LUONG_PCCC_CO_SO = 10,//Lực lượng PCCC Cơ sở
        NHA_CUNG_CAP = 11,//Nhà cung cấp DV/Đại lý lắp đặt.
        NHA_VEN_KY_THUAT = 12,//Nhân viên kỹ thuật CSKH (BO) - Vận hành hệ thống
        CUC_TRUONG = 13,//Cục Trưởng
        TRUONG_PHONG = 14,//Trưởng phòng PC07
        CUSTOM = 15,// Tự tạo role mới
    }

    public enum NoticeType
    {

        FIRE_PROTECTION = 0,
        VIOLATION,
        CONSTRUCTION_CHECKING,
        DEVICE,
        SENSOR
    }

    public enum DeviceErrorType
    {
        LOI_TU_BAO_CHAY = 0,
        PIN_YEU,
        MAT_KET_NOI

    }

}
