using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class TaiKhoan
{
    [Key]
    public string MaTaiKhoan { get; set; } = null!;

    public string? TenTaiKhoan { get; set; }

    public string MatKhau { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public string? Email { get; set; }
    public int TinhTrang { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
//TinhTrang:
//0 : Đã Xóa
//1 : Customer đủ thông Tin
//2 : Customer chưa nhập thông tin
//3 : Nhân Viên 
