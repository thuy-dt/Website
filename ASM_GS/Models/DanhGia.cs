using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class DanhGia
{
    [Key]
    public string MaDanhGia { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string? NoiDung { get; set; }

    public int SoSao { get; set; }
    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
