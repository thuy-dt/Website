using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class NhanVien
{
    [Key] 
    public string MaNhanVien { get; set; } = null!;

    public string TenNhanVien { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public string? HinhAnh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public int? TrangThai { get; set; }

    public string? Cccd { get; set; }

    public bool? GioiTinh { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
//Tình trạng:
//0: Không hoạt động
//1: Hoạt động
