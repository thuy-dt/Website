﻿namespace ASM_GS.ViewModels
{
    public class DonHang_LSViewModel
    {
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public DateOnly NgayXuatHoaDon { get; set; }
        public decimal TongTien { get; set; }
        public int? TrangThai { get; set; }
        public List<ChiTietHoaDon_LSViewModel> ChiTietHoaDons { get; set; }
    }
}
