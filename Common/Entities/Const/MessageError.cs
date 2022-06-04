using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Const
{
    public class MessageError
    {
        public const string ErrorConstructionExits = "Mã CSCT đã tồn tại";

        public const string ErrorSensorExits = "Số seri cảm biến đã tồn tại";
        public const string ErrorSeriSensorExits = "Số seri đã tồn tại";
        public const string ErrorImeiDeviceExits = "IMEI thiết bị đã tồn tại";
        public const string ErrorNameConstructionCheckingPlanExits = "Tên kế hoạch kiểm tra đã tồn tại";
        public const string ErrorConstructionManagementNotFound = "Không tìm thấy lực lượng";
        public const string ErrorConstructionManagementExist = "Lực lượng đơn vị đã tồn tại";
        public const string ErrorDeviceTypeExist = "Không tồn tại loại thiết bị nào trên hệ thống";
        public const string ErrorCodeSupportUnitExits = "Mã đơn vị hỗ trợ đã tồn tại";
        public const string ErrorCodeWaterPointExits = "Mã điểm lấy nước đã tồn tại";
        public const string ErrorCodePCCCExits = "Mã đơn vị PCCC đã tồn tại";
        public const string ErrorPassportFireFighterExits = "Mã CMND/CCCD đã tồn tại";
        public const string ErrorManagerFireFighterExits = "Đã tồn tại người quản lý ở đơn vị";
        public const string ErrorVinFireTruckExits = "Biển số/ số hiệu đã tồn tại";
        public const string ErrorParentIdCustomerExits = "Khách hàng quản lý không được lấy theo khách hàng hiện tại";
        public const string ErrorParentIdCustomerDuplicate = "Khách hàng quản lý đã thuộc quản lý của khách hàng hiện tại";

        public const string ErrorUploadFile= "Upload File không thành công";
        public const string ErrorDeleteFile = "Xóa File không thành công";
        public const string ErrorUploadFormatFile = "Upload File sai định dạng (chỉ up file .png .jpg .pdf)";
        public const string ErrorUploadSizeFile = "Upload File quá dung lượng cho phép (< 20MB)";

        public const string ErroriDeviceNotFound = "Thiết bị không tồn tại";
        public const string ErrorRoleNotFound = "Không tìm thấy vai trò";
        public const string ErrorUserNotFound = "Không tìm thấy người dùng";
        public const string ErrorDataFound = "Không tìm thấy dữ liệu";
        public const string ErrorFireProtectionNotFound = "Không tìm thấy người dùng";

        public const string UpdateSuccess = "Cập nhật thành công";
        public const string CreateSuccess = "Thêm mới thành công";
        public const string ErrorCreate= "Có lỗi trong quá trình thêm mới";
        public const string ErrorUpdate = "Có lỗi trong quá trình cập nhật";

        public const string DeleteSuccess = "Xoá thành công";
        public const string DeleteFail = "Có lỗi trong quá trình xoá";

        public const string DeviceCodeNotFound = "Mã thiết bị không được để trống";
        public const string DeviceCodeExits = "Mã loại thiết bị đã tồn tại";
        public const string DeviceCodeNotExits = "Mã thiết bị không đã tồn tại";
        public const string PairingDeviceIMEINotExits = "IMEI thiết bị kêt nối không tồn tại";

        public const string ErrorCodeNotFound = "Mã lỗi không được để trống";
        public const string ErrorCodeExits = "Mã lỗi đã tồn tại";
        public const string ErrorCodeNotExits = "Mã lỗi không đã tồn tại";
        public const string ErrorNotExits = "Thông tin lỗi không tồn tại";
        public const string ErrorIdNotExits = "Id không được để trống";
      
        public const string NoContent = "Không tìm thấy dữ liệu";
        public const string OutDatePassword = "Không tìm thấy dữ liệu";
        public const string ComparePasswordError = "Mật khẩu gõ lại không trùng.";
        public const string TypingPasswordError = "Mật khẩu cần có tối thiểu 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt";
        public const string LoginError = "Tên đăng nhập hoặc mật khẩu không đúng";
        public const string AccountInActive = "Tài khoản của bạn đã bị khóa, vui lòng liên hệ quản trị viên để được trợ giúp";
        public const string InvalidPasswordCount = "Tài khoản của bạn đã bị khóa do nhập sai mật khẩu quá số lần quy định, vui lòng liên hệ quản trị viên để được trợ giúp";

        public const string ActionFail = "Thao tác không thành công.";
    }
}
