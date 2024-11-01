using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class GiamGia
{
    [Key]
    public string MaGiamGia { get; set; } = null!;

    public string TenGiamGia { get; set; } = null!;

    public decimal GiaTri { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
