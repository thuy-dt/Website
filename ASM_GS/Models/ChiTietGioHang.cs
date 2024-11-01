using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class ChiTietGioHang
{
    [Key]
    public int Id { get; set; }

    public string MaGioHang { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public string? MaCombo { get; set; }

    public int SoLuong { get; set; }

    public virtual Combo? MaComboNavigation { get; set; }

    public virtual GioHang MaGioHangNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
