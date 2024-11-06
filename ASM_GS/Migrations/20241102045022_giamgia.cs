using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class giamgia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_GiamGia_MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "HoaDons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "GiamGia",
                columns: new[] { "MaGiamGia", "GiaTri", "NgayBatDau", "NgayKetThuc", "TenGiamGia" },
                values: new object[,]
                {
                    { "CP001", 0.25m, new DateOnly(2025, 6, 1), new DateOnly(2025, 6, 30), "Giảm giá mùa hè" },
                    { "CP002", 0.15m, new DateOnly(2025, 12, 20), new DateOnly(2025, 12, 25), "Giảm giá Noel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaGiamGia",
                table: "HoaDons",
                column: "MaGiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_GiamGia_MaGiamGia",
                table: "HoaDons",
                column: "MaGiamGia",
                principalTable: "GiamGia",
                principalColumn: "MaGiamGia",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_GiamGia_MaGiamGia",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_MaGiamGia",
                table: "HoaDons");

            migrationBuilder.DeleteData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP001");

            migrationBuilder.DeleteData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP002");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons",
                column: "MaGiamGiaNavigationMaGiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_GiamGia_MaGiamGiaNavigationMaGiamGia",
                table: "HoaDons",
                column: "MaGiamGiaNavigationMaGiamGia",
                principalTable: "GiamGia",
                principalColumn: "MaGiamGia");
        }
    }
}
