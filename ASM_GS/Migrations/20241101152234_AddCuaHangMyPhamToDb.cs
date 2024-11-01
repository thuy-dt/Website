using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class AddCuaHangMyPhamToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    MaCombo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenCombo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.MaCombo);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    MaDanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "GiamGia",
                columns: table => new
                {
                    MaGiamGia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGia", x => x.MaGiamGia);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateOnly>(type: "date", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    NgayThem = table.Column<DateOnly>(type: "date", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nsx = table.Column<DateOnly>(type: "date", nullable: true),
                    Hsd = table.Column<DateOnly>(type: "date", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    MaDanhMucNavigationMaDanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SanPhams_DanhMucs_MaDanhMucNavigationMaDanhMuc",
                        column: x => x.MaDanhMucNavigationMaDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "MaDanhMuc");
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    MaDonHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDatHang = table.Column<DateOnly>(type: "date", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    MaKhachHangNavigationMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    MaGioHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateOnly>(type: "date", nullable: false),
                    MaKhachHangNavigationMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.MaGioHang);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang");
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXuatHoaDon = table.Column<DateOnly>(type: "date", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    MaGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaGiamGiaNavigationMaGiamGia = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaKhachHangNavigationMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDons_GiamGia_MaGiamGiaNavigationMaGiamGia",
                        column: x => x.MaGiamGiaNavigationMaGiamGia,
                        principalTable: "GiamGia",
                        principalColumn: "MaGiamGia");
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKhachHangNavigationMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNhanVienNavigationMaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK_TaiKhoans_NhanViens_MaNhanVienNavigationMaNhanVien",
                        column: x => x.MaNhanVienNavigationMaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "AnhSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnhSanPhams_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCombos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCombo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MaComboNavigationMaCombo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCombos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietCombos_Combos_MaComboNavigationMaCombo",
                        column: x => x.MaComboNavigationMaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietCombos_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    MaDanhGia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoSao = table.Column<int>(type: "int", nullable: false),
                    MaKhachHangNavigationMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_DanhGia_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGia_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    MaChiTietDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaComboNavigationMaCombo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaDonHangNavigationMaDonHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => x.MaChiTietDonHang);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_Combos_MaComboNavigationMaCombo",
                        column: x => x.MaComboNavigationMaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo");
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_DonHangs_MaDonHangNavigationMaDonHang",
                        column: x => x.MaDonHangNavigationMaDonHang,
                        principalTable: "DonHangs",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGioHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MaComboNavigationMaCombo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaGioHangNavigationMaGioHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_Combos_MaComboNavigationMaCombo",
                        column: x => x.MaComboNavigationMaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo");
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_GioHangs_MaGioHangNavigationMaGioHang",
                        column: x => x.MaGioHangNavigationMaGioHang,
                        principalTable: "GioHangs",
                        principalColumn: "MaGioHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaComboNavigationMaCombo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaHoaDonNavigationMaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanPhamNavigationMaSanPham = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_Combos_MaComboNavigationMaCombo",
                        column: x => x.MaComboNavigationMaCombo,
                        principalTable: "Combos",
                        principalColumn: "MaCombo");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHoaDonNavigationMaHoaDon",
                        column: x => x.MaHoaDonNavigationMaHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_MaSanPhamNavigationMaSanPham",
                        column: x => x.MaSanPhamNavigationMaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaComboNavigationMaCombo",
                table: "ChiTietCombos",
                column: "MaComboNavigationMaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_MaComboNavigationMaCombo",
                table: "ChiTietDonHangs",
                column: "MaComboNavigationMaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_MaDonHangNavigationMaDonHang",
                table: "ChiTietDonHangs",
                column: "MaDonHangNavigationMaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_MaSanPhamNavigationMaSanPham",
                table: "ChiTietDonHangs",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_MaComboNavigationMaCombo",
                table: "ChiTietGioHangs",
                column: "MaComboNavigationMaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_MaGioHangNavigationMaGioHang",
                table: "ChiTietGioHangs",
                column: "MaGioHangNavigationMaGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_MaSanPhamNavigationMaSanPham",
                table: "ChiTietGioHangs",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaComboNavigationMaCombo",
                table: "ChiTietHoaDons",
                column: "MaComboNavigationMaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaHoaDonNavigationMaHoaDon",
                table: "ChiTietHoaDons",
                column: "MaHoaDonNavigationMaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaSanPhamNavigationMaSanPham",
                table: "ChiTietHoaDons",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaKhachHangNavigationMaKhachHang",
                table: "DanhGia",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaSanPhamNavigationMaSanPham",
                table: "DanhGia",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_MaKhachHangNavigationMaKhachHang",
                table: "DonHangs",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_MaKhachHangNavigationMaKhachHang",
                table: "GioHangs",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons",
                column: "MaGiamGiaNavigationMaGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaKhachHangNavigationMaKhachHang",
                table: "HoaDons",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams",
                column: "MaDanhMucNavigationMaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_MaKhachHangNavigationMaKhachHang",
                table: "TaiKhoans",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_MaNhanVienNavigationMaNhanVien",
                table: "TaiKhoans",
                column: "MaNhanVienNavigationMaNhanVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhSanPhams");

            migrationBuilder.DropTable(
                name: "ChiTietCombos");

            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "ChiTietGioHangs");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "GiamGia");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "DanhMucs");
        }
    }
}
