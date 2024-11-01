using Microsoft.EntityFrameworkCore;
using ASM_GS.Models;
using Microsoft.Identity.Client;

namespace ASM_GS.Controllers
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; }

        public virtual DbSet<ChiTietCombo> ChiTietCombos { get; set; }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DbSet<Combo> Combos { get; set; }

        public virtual DbSet<DanhGia> DanhGia { get; set; }

        public virtual DbSet<DanhMuc> DanhMucs { get; set; }

        public virtual DbSet<DonHang> DonHangs { get; set; }

        public virtual DbSet<GiamGia> GiamGia { get; set; }

        public virtual DbSet<GioHang> GioHangs { get; set; }

        public virtual DbSet<HoaDon> HoaDons { get; set; }

        public virtual DbSet<KhachHang> KhachHangs { get; set; }

        public virtual DbSet<NhanVien> NhanViens { get; set; }

        public virtual DbSet<SanPham> SanPhams { get; set; }

        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    }
}
