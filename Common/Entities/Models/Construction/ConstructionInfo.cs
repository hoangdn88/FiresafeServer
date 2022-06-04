using Common.Entities.DataTransferObjects;
using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Enum;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.Models
{
    public class ConstructionInfo : GeoBase
    {        
        public string Code { set; get; } // Code công trình
        public string Name { set; get; } // Tên công trình
        public string Approach { set; get; } // Hướng tiếp cận công trình
        public OwnerType? OwnerType { set; get; } // Loại hình sở hữu
        public string PcccUnitId { set; get; } // Đơn vị Pccc
        public string Owner { set; get; } // Chủ cơ sở
        public DateTime? RegisterDate { set; get; } // Ngày đăng ký
        public DateTime? ExpiredDate { set; get; } // Ngày hết hạn đăng ký
        public ManageLevel? ManageLevel { set; get; } // Cấp quản lý
        public List<PhoneNumberInfo> Phonenumber { set; get; } // Số điện thoại
        public string InspectionOfficerId { set; get; } // Cán bộ kiểm tra
        public List<string> AreaManagerId { set; get; } // Cán bộ kiểm tra khu vực   
        public ActivityType? ActivityType { set; get; } // Loại hình hoạt động 
        public EconomicSectors? EconomicSector { set; get; } // Thành phần kinh tế
        public int? EstablishYear { set; get; } // Năm thành lập
        public string Email { set; get; } // Email
        public InvestmentForm? InvestmentForm { set; get; } // Hình thức đầu tư
        public IndustryField? IndustryField { set; get; } // Ngành lĩnh vực
        public string Website { set; get; } // Website        
        public FireInsurance? FireInsurance { set; get; } // Bảo hiểm cháy nổ
        public string CustomerId { set; get; } // Mã khách hàng

        public bool? AlertWrong { set; get; }// Cảnh báo sai nhiều lần
        public bool? DeviceOffline { set; get; }// Thiết bị tòa nhà không hoạt động

        public bool? AlertDelay{ set; get; }// Delay cảnh báo cháy cho trung tâm
                                            //public List<string> FileUrl { get; set; } // Đường dẫn file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
        public DateTime? ApprovePcccDate { set; get; } // ngày phê duyệt PCCC

        public DateTime? AprroveOperateDate { set; get; } // ngày cấp phép hoạt động
        public ConstructionInfo() : base()
        {
            
        }

    }

}
