﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnhSanPhams_SanPhams_MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_DanhMucs_MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_AnhSanPhams_MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams");

            migrationBuilder.DropColumn(
                name: "MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams");

            migrationBuilder.AlterColumn<string>(
                name: "MaDanhMuc",
                table: "SanPhams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "AnhSanPhams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "MaDanhMuc", "TenDanhMuc", "TrangThai" },
                values: new object[,]
                {
                    { "DM001", "Dưỡng da", 1 },
                    { "DM002", "Chống nắng", 1 },
                    { "DM003", "Làm sạch", 1 }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "MaSanPham", "DonVi", "Gia", "Hsd", "MaDanhMuc", "MoTa", "NgayThem", "Nsx", "SoLuong", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { "SP001", null, 300000m, null, "DM001", null, null, null, 100, "Kem dưỡng ẩm", 1 },
                    { "SP002", null, 200000m, null, "DM003", null, null, null, 150, "Sữa rửa mặt", 1 },
                    { "SP003", null, 250000m, null, "DM001", null, null, null, 120, "Nước hoa hồng", 1 },
                    { "SP004", null, 500000m, null, "DM001", null, null, null, 80, "Serum dưỡng trắng", 1 },
                    { "SP005", null, 150000m, null, "DM001", null, null, null, 200, "Mặt nạ cấp ẩm", 1 },
                    { "SP006", null, 350000m, null, "DM002", null, null, null, 90, "Kem chống nắng", 1 },
                    { "SP007", null, 180000m, null, "DM003", null, null, null, 110, "Tẩy trang", 1 },
                    { "SP008", null, 400000m, null, "DM001", null, null, null, 70, "Tinh chất ngừa mụn", 1 },
                    { "SP009", null, 220000m, null, "DM002", null, null, null, 90, "Xịt khoáng", 1 },
                    { "SP010", null, 450000m, null, "DM001", null, null, null, 50, "Kem dưỡng da ban đêm", 1 }
                });

            migrationBuilder.InsertData(
                table: "AnhSanPhams",
                columns: new[] { "Id", "MaSanPham", "UrlAnh" },
                values: new object[,]
                {
                    { 1, "SP001", "wwwroot/img/AnhSanPham/sp001_1.jpg" },
                    { 2, "SP001", "wwwroot/img/AnhSanPham/sp001_2.jpg" },
                    { 3, "SP001", "wwwroot/img/AnhSanPham/sp001_3.jpg" },
                    { 4, "SP001", "wwwroot/img/AnhSanPham/sp001_4.jpg" },
                    { 5, "SP002", "wwwroot/img/AnhSanPham/sp002_1.jpg" },
                    { 6, "SP002", "wwwroot/img/AnhSanPham/sp002_2.jpg" },
                    { 7, "SP002", "wwwroot/img/AnhSanPham/sp002_3.jpg" },
                    { 8, "SP002", "wwwroot/img/AnhSanPham/sp002_4.jpg" },
                    { 9, "SP003", "wwwroot/img/AnhSanPham/sp003_1.jpg" },
                    { 10, "SP003", "wwwroot/img/AnhSanPham/sp003_2.jpg" },
                    { 11, "SP003", "wwwroot/img/AnhSanPham/sp003_3.jpg" },
                    { 12, "SP003", "wwwroot/img/AnhSanPham/sp003_4.jpg" },
                    { 13, "SP004", "wwwroot/img/AnhSanPham/sp004_1.jpg" },
                    { 14, "SP004", "wwwroot/img/AnhSanPham/sp004_2.jpg" },
                    { 15, "SP004", "wwwroot/img/AnhSanPham/sp004_3.jpg" },
                    { 16, "SP004", "wwwroot/img/AnhSanPham/sp004_4.jpg" },
                    { 17, "SP005", "wwwroot/img/AnhSanPham/sp005_1.jpg" },
                    { 18, "SP005", "wwwroot/img/AnhSanPham/sp005_2.jpg" },
                    { 19, "SP005", "wwwroot/img/AnhSanPham/sp005_3.jpg" },
                    { 20, "SP005", "wwwroot/img/AnhSanPham/sp005_4.jpg" },
                    { 21, "SP006", "wwwroot/img/AnhSanPham/sp006_1.jpg" },
                    { 22, "SP006", "wwwroot/img/AnhSanPham/sp006_2.jpg" },
                    { 23, "SP006", "wwwroot/img/AnhSanPham/sp006_3.jpg" },
                    { 24, "SP006", "wwwroot/img/AnhSanPham/sp006_4.jpg" },
                    { 25, "SP007", "wwwroot/img/AnhSanPham/sp007_1.jpg" },
                    { 26, "SP007", "wwwroot/img/AnhSanPham/sp007_2.jpg" },
                    { 27, "SP007", "wwwroot/img/AnhSanPham/sp007_3.jpg" },
                    { 28, "SP007", "wwwroot/img/AnhSanPham/sp007_4.jpg" },
                    { 29, "SP008", "wwwroot/img/AnhSanPham/sp008_1.jpg" },
                    { 30, "SP008", "wwwroot/img/AnhSanPham/sp008_2.jpg" },
                    { 31, "SP008", "wwwroot/img/AnhSanPham/sp008_3.jpg" },
                    { 32, "SP008", "wwwroot/img/AnhSanPham/sp008_4.jpg" },
                    { 33, "SP009", "wwwroot/img/AnhSanPham/sp009_1.jpg" },
                    { 34, "SP009", "wwwroot/img/AnhSanPham/sp009_2.jpg" },
                    { 35, "SP009", "wwwroot/img/AnhSanPham/sp009_3.jpg" },
                    { 36, "SP009", "wwwroot/img/AnhSanPham/sp009_4.jpg" },
                    { 37, "SP010", "wwwroot/img/AnhSanPham/sp010_1.jpg" },
                    { 38, "SP010", "wwwroot/img/AnhSanPham/sp010_2.jpg" },
                    { 39, "SP010", "wwwroot/img/AnhSanPham/sp010_3.jpg" },
                    { 40, "SP010", "wwwroot/img/AnhSanPham/sp010_4.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaDanhMuc",
                table: "SanPhams",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_MaSanPham",
                table: "AnhSanPhams",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_AnhSanPhams_SanPhams_MaSanPham",
                table: "AnhSanPhams",
                column: "MaSanPham",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_DanhMucs_MaDanhMuc",
                table: "SanPhams",
                column: "MaDanhMuc",
                principalTable: "DanhMucs",
                principalColumn: "MaDanhMuc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnhSanPhams_SanPhams_MaSanPham",
                table: "AnhSanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_DanhMucs_MaDanhMuc",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_MaDanhMuc",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_AnhSanPhams_MaSanPham",
                table: "AnhSanPhams");

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP001");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP002");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP003");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP004");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP005");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP006");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP007");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP008");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP009");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSanPham",
                keyValue: "SP010");

            migrationBuilder.DeleteData(
                table: "DanhMucs",
                keyColumn: "MaDanhMuc",
                keyValue: "DM001");

            migrationBuilder.DeleteData(
                table: "DanhMucs",
                keyColumn: "MaDanhMuc",
                keyValue: "DM002");

            migrationBuilder.DeleteData(
                table: "DanhMucs",
                keyColumn: "MaDanhMuc",
                keyValue: "DM003");

            migrationBuilder.AlterColumn<string>(
                name: "MaDanhMuc",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "AnhSanPhams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams",
                column: "MaDanhMucNavigationMaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_AnhSanPhams_SanPhams_MaSanPhamNavigationMaSanPham",
                table: "AnhSanPhams",
                column: "MaSanPhamNavigationMaSanPham",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_DanhMucs_MaDanhMucNavigationMaDanhMuc",
                table: "SanPhams",
                column: "MaDanhMucNavigationMaDanhMuc",
                principalTable: "DanhMucs",
                principalColumn: "MaDanhMuc");
        }
    }
}
