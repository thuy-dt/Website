using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class GioHang
{
    [Key]
    public string MaGioHang { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public DateOnly NgayTao { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
