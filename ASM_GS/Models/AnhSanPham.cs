using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class AnhSanPham
{
    [Key]
    public int Id { get; set; }

    public string MaSanPham { get; set; } = null!;

    public string UrlAnh { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
