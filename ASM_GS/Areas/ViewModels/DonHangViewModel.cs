using System;
using System.Collections.Generic;

namespace ASM_GS.ViewModels
{
    public class DonHangViewModel
    {
        public string MaDonHang { get; set; }
        public string MaKhachHang { get; set; }
        public DateOnly NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public List<ChiTietDonHangViewModel> ChiTietDonHangs { get; set; }
    }
}
