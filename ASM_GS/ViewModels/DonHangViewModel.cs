namespace ASM_GS.ViewModels
{
    public class DonHangViewModel
    {
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public DateOnly NgayXuatHoaDon { get; set; }
        public decimal TongTien { get; set; }
        public int? TrangThai { get; set; }
        public List<ChiTietHoaDonViewModel> ChiTietHoaDons { get; set; }
    }
}
