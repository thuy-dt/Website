using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models;

public partial class DonHang
{
    [Key]
    public string MaDonHang { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public DateOnly NgayDatHang { get; set; }

    public decimal TongTien { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
