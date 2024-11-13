using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // Thêm thư viện này cho IFormFile

namespace ASM_GS.Models
{
    public partial class KhachHang
    {
        [Key]
        public string MaKhachHang { get; set; } = null!;

        public string TenKhachHang { get; set; } = null!;
        public string? SoDienThoai { get; set; }

        public string? DiaChi { get; set; }
        public DateOnly NgayDangKy { get; set; }

        public string? HinhAnh { get; set; }

        [NotMapped]
        public IFormFile Anh { get; set; }

        public string? Cccd { get; set; }

        public DateOnly? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public int? TrangThai { get; set; }

        public virtual ICollection<DanhGia> DanhGia { get; set; } = new List<DanhGia>();

        public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

        public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
    }
}
