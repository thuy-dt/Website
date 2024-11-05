using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class ChiTietCombo
{
    [Key]
    public int Id { get; set; }

    public string MaCombo { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public int SoLuong { get; set; }

    public virtual Combo MaComboNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
