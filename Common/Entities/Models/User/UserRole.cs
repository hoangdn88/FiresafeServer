using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class UserRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
    }


    public enum UserPermission
    {


        // Thông tin cá nhân
        PERSONAL_ACCOUNT_VIEW =1,
        PERSONAL_ACCOUNT_EDIT,
        PERSONAL_ACCOUNT_DELETE,

        // Quản lý người dùng
        USER_ACCOUNT_VIEW,
        USER_ACCOUNT_EDIT,
        USER_ACCOUNT_DELETE,

        // Quản lý lịch sử người dùng: ls đăng nhập, ls thao tác
        USER_HISTORY_VIEW,
        USER_HISTORY_EDIT,
        USER_HISTORY_DELETE,

        // Quản lý danh mục
        CATEGORY_VIEW,
        CATEGORY_EDIT,
        CATEGORY_DELETE,

        // Giám sát trực tuyến
        MONITORING_DASHBOARD_VIEW,
        MONITORING_HANDLER_FROM_DEVICE, // Xử lý cảnh báo cháy từ thiết bị
        MONITORING_CREATE_ALERT, // Tạo điểm cháy
        MONITORING_CREATE_CNCH, // Tạo điểm CNCH

        // Quản lý cán bộ, chiến sĩ
        CBCS_VIEW,
        CBCS_EDIT,
        CBCS_DELETE,

        // Quản lý phương tiện
        FIRE_TRUCK_VIEW,
        FIRE_TRUCK_EDIT,
        FIRE_TRUCK_DELETE,

        // Quản lý lính cứu hỏa
        FIRE_FIGHTER_VIEW,
        FIRE_FIGHTER_EDIT,
        FIRE_FIGHTER_DELETE,

        // Quản lý đơn vị hỗ trợ
        SUPPORT_UNIT_VIEW,
        SUPPORT_UNIT_EDIT,
        SUPPORT_UNIT_DELETE,

        // Quản lý điểm lấy nước
        WATER_POINT_VIEW,
        WATER_POINT_EDIT,
        WATER_POINT_DELETE,

        // Cơ sở công trình
        CONSTRUCTION_VIEW,
        CONSTRUCTION_EDIT,
        CONSTRUCTION_DELETE,

        // Kiểm tra CSCT
        CONSTRUCTION_CHECKING_VIEW,
        CONSTRUCTION_CHECKING_EDIT,
        CONSTRUCTION_CHECKING_DELETE,

        // Kiểm tra ke hoach CSCT
        CONSTRUCTION_CHECKING_PLAN_VIEW,
        CONSTRUCTION_CHECKING_PLAN_EDIT,
        CONSTRUCTION_CHECKING_PLAN_DELETE,

        // Thẩm duyệt, nghiệm thu PCCC & CNCH
        CONSTRUCTION_APPROVAL_VIEW,
        CONSTRUCTION_APPROVAL_EDIT,
        CONSTRUCTION_APPROVAL_DELETE,

        // Công tác tuyên truyền, huấn luyện
        PROPAGAE_VIEW,
        PROPAGAE_EDIT,
        PROPAGAE_DELETE,

        // Công tác kiểm định phương tiện PCCC & CNCH


        // Xử lý vi phạm
        VIOLATION_VIEW,
        VIOLATION_EDIT,
        VIOLATION_DELETE,

        // Quản lý cơ sở kinh doanh PCCC

        // Lịch trực
        DUTY_SCHEDULE_VIEW,
        DUTY_SCHEDULE_EDIT,
        DUTY_SCHEDULE_DELETE,

        // Đăng ký Lịch trực
        DUTY_REGIST_VIEW,
        DUTY_REGIST_EDIT,
        DUTY_REGIST_DELETE,

        // Quản lý công tác xây dựng và thực tập phương án chữa cháy, CNCH
        PLANING_VIEW,
        PLANING_EDIT,
        PLANING_DELETE,

        // Quản lý công tác chữa cháy
        FIRE_PROTECTION_VIEW,
        FIRE_PROTECTION_EDIT,
        FIRE_PROTECTION_DELETE,

        // Quản lý cứu nạn cứu hộ
        RESCUE_WORK_VIEW,
        RESCUE_WORK_EDIT,
        RESCUE_WORK_DELETE,

        // Quản lý thiết bị
        DEVICE_VIEW,
        DEVICE_EDIT,
        DEVICE_DELETE,

        // Quản lý Khach hang
        CUSTOMER_VIEW,
        CUSTOMER_EDIT,
        CUSTOMER_DELETE,

        // Quản lý certificate
        CERTIFICATE_VIEW,
        CERTIFICATE_EDIT,
        CERTIFICATE_DELETE,

        // Báo cáo
        REPORT_KIEM_TRA_AT_PCCC_VIEW,
        REPORT_KIEM_TRA_AT_PCCC_EXPORT,

        REPORT_NGHIEM_THU_PHE_DUYET_VIEW,
        REPORT_NGHIEM_THU_PHE_DUYET_EXPORT,

        REPORT_CO_SO_CONG_TRINH_VIEW,
        REPORT_CO_SO_CONG_TRINH_EXPORT,

        REPORT_CONG_TAC_CHUA_CHAY_VIEW,
        REPORT_CONG_TAC_CHUA_CHAY_EXPORT,

        REPORT_CNCH_VIEW,
        REPORT_CNCH_EXPORT,

        REPORT_FIRE_TRUCK_VIEW,
        REPORT_FIRE_TRUCK_EXPORT,

        REPORT_DEVICE_VIEW,
        REPORT_DEVICE_EXPORT,
        DASHBOARD_VIEW,

        NOTICE_VIEW,
        NOTICE_EDIT,
        NOTICE_DELETE,
        // Quản lý sản xuất
        FACT_VIEW,
        FACT_EDIT,
        FACT_DELETE,
        FACT_REPORT_VIEW,

        // Quản lý đơn vị PCCC
        PCCC_UNIT_VIEW,
        PCCC_UNIT_EDIT,
        PCCC_UNIT_DELETE,

        //admin 
        ADMIN = 999,
    }
}
