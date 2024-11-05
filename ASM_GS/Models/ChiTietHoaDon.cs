using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class ChiTietHoaDon
{
    [Key]
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public string? MaCombo { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public virtual Combo? MaComboNavigation { get; set; }

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
