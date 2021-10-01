using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthStore.Models
{
    [MetadataTypeAttribute(typeof(ThanhVienMetadata))]

    public partial class ThanhVien
    {

        internal sealed class ThanhVienMetadata
        {

            [DisplayName("Tài Khoản")]
            [Required(ErrorMessage = "{0} Không được để trống tên tài khoản !")]
            [StringLength(10, ErrorMessage = "Tài khoản không được quá 10 ký tự")]
            public string TaiKhoan { get; set; }

            [DisplayName("Mật Khẩu")]
            [Required(ErrorMessage = "{0} Không được để trống mật khẩu !")]
            [StringLength(12, ErrorMessage = "Mật khẩu không được quá 12 ký tự")]
            public string MatKhau { get; set; }

            [DisplayName("Họ và Tên")]
            [Required(ErrorMessage = "{0} Không được để tên trống !")]
            [StringLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]
            public string HoTen { get; set; }

            [DisplayName("Địa Chỉ")]
            [Required(ErrorMessage = "{0} Không được để địa chỉ trống !")]
            [StringLength(50, ErrorMessage = "Địa chỉ không được quá 50 ký tự")]
            public string DiaChi { get; set; }

            [DisplayName("Email")]
            [Required(ErrorMessage = "{0} Không được để mail trống !")]
            [StringLength(50, ErrorMessage = "Mail không được quá 50 ký tự")]
            public string Email { get; set; }

            [DisplayName("Số Điện Thoại")]
            [Required(ErrorMessage = "{0} Không được để SDT trống !")]
            [StringLength(50, ErrorMessage = "SDT không được quá 50 ký tự")]
            public string SoDienThoai { get; set; }

            [DisplayName("Câu Hỏi")]
            public string CauHoi { get; set; }

            [DisplayName("Câu Trả Lời")]
            [Required(ErrorMessage = "{0} Không được để trả lời trống !")]
            [StringLength(50, ErrorMessage = "Trả lời không được quá 50 ký tự")]
            public string CauTraLoi { get; set; }

            public Nullable<int> MaLoaiTV { get; set; }

        }

    }
}