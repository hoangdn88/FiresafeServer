using Common.Entities.Enum;
using Common.Entities.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class ConstructionForUpdateDto : UpdateBase
    {

        [JsonPropertyName("MaCoSoCongTrinh")]
        public string Code { set; get; } // Code công trình

        [JsonPropertyName("TenCoSoCongTrinh")]
        public string Name { set; get; } // Tên công trình

        [JsonPropertyName("HuongVaoTiepCanCSCT")]
        public string Approach { set; get; } // Hướng tiếp cận công trình

        [JsonPropertyName("LoaiHinhSoHuu")]
        public OwnerType? OwnerType { set; get; } // Loại hình sở hữu

        [JsonPropertyName("DonViPcccID")]
        public string PcccUnitId { set; get; } // Đơn vị Pccc

        public string LocationDetail { set; get; } // Địa chỉ cụ thể

        [JsonPropertyName("ChuCSCT")]
        public string Owner { set; get; } // Chủ cơ sở

        public LocationInfoDto Location { set; get; } // Địa chỉ hành chính

        public DateTime? RegisterDate { set; get; } // Ngày đăng ký
        public DateTime? ExpiredDate { set; get; } // Ngày hết hạn đăng ký

        [JsonPropertyName("CapQuanLy")]        
        public ManageLevel? ManageLevel { set; get; } // Cấp quản lý

        [JsonPropertyName("SoDienThoai")]
        public List<PhoneNumberInfo> Phonenumber { set; get; } // Số điện thoại

        public string InspectionOfficerId { set; get; } // Cán bộ kiểm tra

        [JsonPropertyName("CanBoKiemTra")]
        public List<string> AreaManagerId { set; get; } // Cán bộ kiểm tra khu vực

        [JsonPropertyName("LoaiHinhHoatDong")]        
        public ActivityType? ActivityType { set; get; } // Loại hình hoạt động

        [JsonPropertyName("ThanhPhanKinhTe")]        
        public EconomicSectors? EconomicSector { set; get; } // Thành phần kinh tế

        [JsonPropertyName("NamThanhLap")]
        public int? EstablishYear { set; get; } // Năm thành lập

        [JsonPropertyName("Email")]
        public string Email { set; get; } // Email

        [JsonPropertyName("HinhThucDauTu")]        
        public InvestmentForm? InvestmentForm { set; get; } // Hình thức đầu tư

        [JsonPropertyName("NghanhLinhVuc")]
        public IndustryField IndustryField { set; get; } // Ngành lĩnh vực

        [JsonPropertyName("Website")]
        public string Website { set; get; } // Website

        [JsonPropertyName("BaoHiemChayNo")]        
        public FireInsurance? FireInsurance { set; get; } // Bảo hiểm cháy nổ

        public double? Longitude { set; get; } // Kinh độ

        public double? Latitude { set; get; } // Vĩ độ
        public DateTime? ApprovePcccDate { set; get; } // ngày phê duyệt PCCC

        public DateTime? AprroveOperateDate { set; get; } // ngày cấp phép hoạt động

        public string CustomerId { set; get; } // Mã khách hàng
        public bool? AlertDelay { set; get; }// Delay cảnh báo cháy cho trung tâm
        //public List<string> FileUrl { get; set; } // Đường dẫn file đính kèm
        public List<FileNameAndUrl> FileNameUrl { get; set; } // Đường dẫn file đính kèm + name
    }
}
