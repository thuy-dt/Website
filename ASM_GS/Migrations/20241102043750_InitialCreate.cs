using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCombos_Combos_MaComboNavigationMaCombo",
                table: "ChiTietCombos");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCombos_SanPhams_MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCombos_MaComboNavigationMaCombo",
                table: "ChiTietCombos");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCombos_MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos");

            migrationBuilder.DropColumn(
                name: "MaComboNavigationMaCombo",
                table: "ChiTietCombos");

            migrationBuilder.DropColumn(
                name: "MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos");

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "ChiTietCombos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaCombo",
                table: "ChiTietCombos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/kemduongam1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/kemduongam2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/kemduongam3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/kemduongam4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/suaruamat1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 6,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/suaruamat2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 7,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/suaruamat3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 8,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/suaruamat4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 9,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/toner1.png");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 10,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/toner2.png");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 11,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/toner3.png");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 12,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/toner4.png");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 13,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/serumtrang1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 14,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/serumtrang2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 15,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/serumtrang3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 16,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/serumtrang4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 17,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/mark1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 18,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/mark2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 19,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/mark3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 20,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/mark4.jpg");

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "MaCombo", "Gia", "MoTa", "TenCombo" },
                values: new object[,]
                {
                    { "CB001", 800000m, "Combo gồm các sản phẩm dưỡng ẩm", "Combo Dưỡng Ẩm" },
                    { "CB002", 1200000m, "Combo chăm sóc da toàn diện", "Combo Chăm Sóc Da" },
                    { "CB003", 950000m, "Combo sản phẩm ngừa mụn hiệu quả", "Combo Ngừa Mụn" }
                });

            migrationBuilder.InsertData(
                table: "ChiTietCombos",
                columns: new[] { "Id", "MaCombo", "MaSanPham", "SoLuong" },
                values: new object[,]
                {
                    { 1, "CB001", "SP001", 1 },
                    { 2, "CB001", "SP005", 1 },
                    { 3, "CB001", "SP006", 1 },
                    { 4, "CB002", "SP002", 1 },
                    { 5, "CB002", "SP003", 1 },
                    { 6, "CB002", "SP004", 1 },
                    { 7, "CB002", "SP010", 1 },
                    { 8, "CB003", "SP008", 1 },
                    { 9, "CB003", "SP007", 1 },
                    { 10, "CB003", "SP009", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaCombo",
                table: "ChiTietCombos",
                column: "MaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaSanPham",
                table: "ChiTietCombos",
                column: "MaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCombos_Combos_MaCombo",
                table: "ChiTietCombos",
                column: "MaCombo",
                principalTable: "Combos",
                principalColumn: "MaCombo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCombos_SanPhams_MaSanPham",
                table: "ChiTietCombos",
                column: "MaSanPham",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCombos_Combos_MaCombo",
                table: "ChiTietCombos");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCombos_SanPhams_MaSanPham",
                table: "ChiTietCombos");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCombos_MaCombo",
                table: "ChiTietCombos");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCombos_MaSanPham",
                table: "ChiTietCombos");

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ChiTietCombos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB001");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB002");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB003");

            migrationBuilder.AlterColumn<string>(
                name: "MaSanPham",
                table: "ChiTietCombos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MaCombo",
                table: "ChiTietCombos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MaComboNavigationMaCombo",
                table: "ChiTietCombos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp001_1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp001_2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp001_3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp001_4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp002_1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 6,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp002_2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 7,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp002_3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 8,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp002_4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 9,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp003_1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 10,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp003_2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 11,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp003_3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 12,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp003_4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 13,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp004_1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 14,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp004_2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 15,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp004_3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 16,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp004_4.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 17,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp005_1.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 18,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp005_2.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 19,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp005_3.jpg");

            migrationBuilder.UpdateData(
                table: "AnhSanPhams",
                keyColumn: "Id",
                keyValue: 20,
                column: "UrlAnh",
                value: "wwwroot/img/AnhSanPham/sp005_4.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaComboNavigationMaCombo",
                table: "ChiTietCombos",
                column: "MaComboNavigationMaCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCombos_MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos",
                column: "MaSanPhamNavigationMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCombos_Combos_MaComboNavigationMaCombo",
                table: "ChiTietCombos",
                column: "MaComboNavigationMaCombo",
                principalTable: "Combos",
                principalColumn: "MaCombo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCombos_SanPhams_MaSanPhamNavigationMaSanPham",
                table: "ChiTietCombos",
                column: "MaSanPhamNavigationMaSanPham",
                principalTable: "SanPhams",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
