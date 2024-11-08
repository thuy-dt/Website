using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class HoaDon
{
    [Key]
    public string MaHoaDon { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public DateOnly NgayXuatHoaDon { get; set; }

    public decimal TongTien { get; set; }

    public int? TrangThai { get; set; }

    public string? MaGiamGia { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual GiamGia? MaGiamGiaNavigation { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
    
}
