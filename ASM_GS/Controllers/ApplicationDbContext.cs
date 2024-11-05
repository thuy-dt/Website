using Microsoft.EntityFrameworkCore;
using ASM_GS.Models;

namespace ASM_GS.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ giữa SanPham và AnhSanPham
            modelBuilder.Entity<AnhSanPham>()
                .HasOne(a => a.MaSanPhamNavigation)
                .WithMany(s => s.AnhSanPhams)
                .HasForeignKey(a => a.MaSanPham);

            // Cấu hình quan hệ giữa SanPham và DanhMuc
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.MaDanhMucNavigation)
                .WithMany(d => d.SanPhams)
                .HasForeignKey(s => s.MaDanhMuc);

            // Seed Data cho DanhMuc
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc { MaDanhMuc = "DM001", TenDanhMuc = "Dưỡng da", TrangThai = 1 },
                new DanhMuc { MaDanhMuc = "DM002", TenDanhMuc = "Chống nắng", TrangThai = 1 },
                new DanhMuc { MaDanhMuc = "DM003", TenDanhMuc = "Làm sạch", TrangThai = 1 }
            );

            // Seed Data cho SanPham (10 sản phẩm skincare)
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham { MaSanPham = "SP001", TenSanPham = "Kem dưỡng ẩm", Gia = 300000, MaDanhMuc = "DM001", SoLuong = 100, TrangThai = 1 },
                new SanPham { MaSanPham = "SP002", TenSanPham = "Sữa rửa mặt", Gia = 200000, MaDanhMuc = "DM003", SoLuong = 150, TrangThai = 1 },
                new SanPham { MaSanPham = "SP003", TenSanPham = "Nước hoa hồng", Gia = 250000, MaDanhMuc = "DM001", SoLuong = 120, TrangThai = 1 },
                new SanPham { MaSanPham = "SP004", TenSanPham = "Serum dưỡng trắng", Gia = 500000, MaDanhMuc = "DM001", SoLuong = 80, TrangThai = 1 },
                new SanPham { MaSanPham = "SP005", TenSanPham = "Mặt nạ cấp ẩm", Gia = 150000, MaDanhMuc = "DM001", SoLuong = 200, TrangThai = 1 },
                new SanPham { MaSanPham = "SP006", TenSanPham = "Kem chống nắng", Gia = 350000, MaDanhMuc = "DM002", SoLuong = 90, TrangThai = 1 },
                new SanPham { MaSanPham = "SP007", TenSanPham = "Tẩy trang", Gia = 180000, MaDanhMuc = "DM003", SoLuong = 110, TrangThai = 1 },
                new SanPham { MaSanPham = "SP008", TenSanPham = "Tinh chất ngừa mụn", Gia = 400000, MaDanhMuc = "DM001", SoLuong = 70, TrangThai = 1 },
                new SanPham { MaSanPham = "SP009", TenSanPham = "Xịt khoáng", Gia = 220000, MaDanhMuc = "DM002", SoLuong = 90, TrangThai = 1 },
                new SanPham { MaSanPham = "SP010", TenSanPham = "Kem dưỡng da ban đêm", Gia = 450000, MaDanhMuc = "DM001", SoLuong = 50, TrangThai = 1 }
            );

            modelBuilder.Entity<AnhSanPham>().HasData(
               // 4 ảnh cho sản phẩm SP001
               new AnhSanPham { Id = 1, MaSanPham = "SP001", UrlAnh = "wwwroot/img/AnhSanPham/sp001_1.jpg" },
               new AnhSanPham { Id = 2, MaSanPham = "SP001", UrlAnh = "wwwroot/img/AnhSanPham/sp001_2.jpg" },
               new AnhSanPham { Id = 3, MaSanPham = "SP001", UrlAnh = "wwwroot/img/AnhSanPham/sp001_3.jpg" },
               new AnhSanPham { Id = 4, MaSanPham = "SP001", UrlAnh = "wwwroot/img/AnhSanPham/sp001_4.jpg" },

               // 4 ảnh cho sản phẩm SP002
               new AnhSanPham { Id = 5, MaSanPham = "SP002", UrlAnh = "wwwroot/img/AnhSanPham/sp002_1.jpg" },
               new AnhSanPham { Id = 6, MaSanPham = "SP002", UrlAnh = "wwwroot/img/AnhSanPham/sp002_2.jpg" },
               new AnhSanPham { Id = 7, MaSanPham = "SP002", UrlAnh = "wwwroot/img/AnhSanPham/sp002_3.jpg" },
               new AnhSanPham { Id = 8, MaSanPham = "SP002", UrlAnh = "wwwroot/img/AnhSanPham/sp002_4.jpg" },

               // 4 ảnh cho sản phẩm SP003
               new AnhSanPham { Id = 9, MaSanPham = "SP003", UrlAnh = "wwwroot/img/AnhSanPham/sp003_1.jpg" },
               new AnhSanPham { Id = 10, MaSanPham = "SP003", UrlAnh = "wwwroot/img/AnhSanPham/sp003_2.jpg" },
               new AnhSanPham { Id = 11, MaSanPham = "SP003", UrlAnh = "wwwroot/img/AnhSanPham/sp003_3.jpg" },
               new AnhSanPham { Id = 12, MaSanPham = "SP003", UrlAnh = "wwwroot/img/AnhSanPham/sp003_4.jpg" },

               // 4 ảnh cho sản phẩm SP004
               new AnhSanPham { Id = 13, MaSanPham = "SP004", UrlAnh = "wwwroot/img/AnhSanPham/sp004_1.jpg" },
               new AnhSanPham { Id = 14, MaSanPham = "SP004", UrlAnh = "wwwroot/img/AnhSanPham/sp004_2.jpg" },
               new AnhSanPham { Id = 15, MaSanPham = "SP004", UrlAnh = "wwwroot/img/AnhSanPham/sp004_3.jpg" },
               new AnhSanPham { Id = 16, MaSanPham = "SP004", UrlAnh = "wwwroot/img/AnhSanPham/sp004_4.jpg" },

               // 4 ảnh cho sản phẩm SP005
               new AnhSanPham { Id = 17, MaSanPham = "SP005", UrlAnh = "wwwroot/img/AnhSanPham/sp005_1.jpg" },
               new AnhSanPham { Id = 18, MaSanPham = "SP005", UrlAnh = "wwwroot/img/AnhSanPham/sp005_2.jpg" },
               new AnhSanPham { Id = 19, MaSanPham = "SP005", UrlAnh = "wwwroot/img/AnhSanPham/sp005_3.jpg" },
               new AnhSanPham { Id = 20, MaSanPham = "SP005", UrlAnh = "wwwroot/img/AnhSanPham/sp005_4.jpg" },

               // 4 ảnh cho sản phẩm SP006
               new AnhSanPham { Id = 21, MaSanPham = "SP006", UrlAnh = "wwwroot/img/AnhSanPham/sp006_1.jpg" },
               new AnhSanPham { Id = 22, MaSanPham = "SP006", UrlAnh = "wwwroot/img/AnhSanPham/sp006_2.jpg" },
               new AnhSanPham { Id = 23, MaSanPham = "SP006", UrlAnh = "wwwroot/img/AnhSanPham/sp006_3.jpg" },
               new AnhSanPham { Id = 24, MaSanPham = "SP006", UrlAnh = "wwwroot/img/AnhSanPham/sp006_4.jpg" },

               // 4 ảnh cho sản phẩm SP007
               new AnhSanPham { Id = 25, MaSanPham = "SP007", UrlAnh = "wwwroot/img/AnhSanPham/sp007_1.jpg" },
               new AnhSanPham { Id = 26, MaSanPham = "SP007", UrlAnh = "wwwroot/img/AnhSanPham/sp007_2.jpg" },
               new AnhSanPham { Id = 27, MaSanPham = "SP007", UrlAnh = "wwwroot/img/AnhSanPham/sp007_3.jpg" },
               new AnhSanPham { Id = 28, MaSanPham = "SP007", UrlAnh = "wwwroot/img/AnhSanPham/sp007_4.jpg" },

               // 4 ảnh cho sản phẩm SP008
               new AnhSanPham { Id = 29, MaSanPham = "SP008", UrlAnh = "wwwroot/img/AnhSanPham/sp008_1.jpg" },
               new AnhSanPham { Id = 30, MaSanPham = "SP008", UrlAnh = "wwwroot/img/AnhSanPham/sp008_2.jpg" },
               new AnhSanPham { Id = 31, MaSanPham = "SP008", UrlAnh = "wwwroot/img/AnhSanPham/sp008_3.jpg" },
               new AnhSanPham { Id = 32, MaSanPham = "SP008", UrlAnh = "wwwroot/img/AnhSanPham/sp008_4.jpg" },

               // 4 ảnh cho sản phẩm SP009
               new AnhSanPham { Id = 33, MaSanPham = "SP009", UrlAnh = "wwwroot/img/AnhSanPham/sp009_1.jpg" },
               new AnhSanPham { Id = 34, MaSanPham = "SP009", UrlAnh = "wwwroot/img/AnhSanPham/sp009_2.jpg" },
               new AnhSanPham { Id = 35, MaSanPham = "SP009", UrlAnh = "wwwroot/img/AnhSanPham/sp009_3.jpg" },
               new AnhSanPham { Id = 36, MaSanPham = "SP009", UrlAnh = "wwwroot/img/AnhSanPham/sp009_4.jpg" },

               // 4 ảnh cho sản phẩm SP010
               new AnhSanPham { Id = 37, MaSanPham = "SP010", UrlAnh = "wwwroot/img/AnhSanPham/sp010_1.jpg" },
               new AnhSanPham { Id = 38, MaSanPham = "SP010", UrlAnh = "wwwroot/img/AnhSanPham/sp010_2.jpg" },
               new AnhSanPham { Id = 39, MaSanPham = "SP010", UrlAnh = "wwwroot/img/AnhSanPham/sp010_3.jpg" },
               new AnhSanPham { Id = 40, MaSanPham = "SP010", UrlAnh = "wwwroot/img/AnhSanPham/sp010_4.jpg" }
           );
        }
    }
}
