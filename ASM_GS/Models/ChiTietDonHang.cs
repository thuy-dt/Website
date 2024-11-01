using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class ChiTietDonHang
{
    [Key]
    public int MaChiTietDonHang { get; set; }

    public string MaDonHang { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public string? MaCombo { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public virtual Combo? MaComboNavigation { get; set; }

    public virtual DonHang MaDonHangNavigation { get; set; } = null!;

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
