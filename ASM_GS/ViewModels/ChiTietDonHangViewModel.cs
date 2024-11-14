namespace ASM_GS.ViewModels
{
    public class ChiTietDonHangViewModel  // Renamed to match usage in Razor view
    {
        public int MaChiTietDonHang { get; set; }

        public string MaDonHang { get; set; }

        public string? MaSanPham { get; set; }

        public string? MaCombo { get; set; }

        public int SoLuong { get; set; }

        public decimal Gia { get; set; }

        // Optionally, you can add navigation properties if needed
        public string SanPhamName { get; set; }
        public string ComboName { get; set; }
    }
}
