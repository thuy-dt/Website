using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class AddDuLieuMoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaNhapGiamGia_GiamGia_GiamGiaMaGiamGia",
                table: "MaNhapGiamGia");

            migrationBuilder.DropIndex(
                name: "IX_MaNhapGiamGia_GiamGiaMaGiamGia",
                table: "MaNhapGiamGia");

            migrationBuilder.DropColumn(
                name: "GiamGiaMaGiamGia",
                table: "MaNhapGiamGia");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "MaNhapGiamGia",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP001",
                column: "SoLuongMaNhapToiDa",
                value: 100);

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP002",
                column: "SoLuongMaNhapToiDa",
                value: 100);

            migrationBuilder.CreateIndex(
                name: "IX_MaNhapGiamGia_MaGiamGia",
                table: "MaNhapGiamGia",
                column: "MaGiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_MaNhapGiamGia_GiamGia_MaGiamGia",
                table: "MaNhapGiamGia",
                column: "MaGiamGia",
                principalTable: "GiamGia",
                principalColumn: "MaGiamGia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaNhapGiamGia_GiamGia_MaGiamGia",
                table: "MaNhapGiamGia");

            migrationBuilder.DropIndex(
                name: "IX_MaNhapGiamGia_MaGiamGia",
                table: "MaNhapGiamGia");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "MaNhapGiamGia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GiamGiaMaGiamGia",
                table: "MaNhapGiamGia",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP001",
                column: "SoLuongMaNhapToiDa",
                value: 0);

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP002",
                column: "SoLuongMaNhapToiDa",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaNhapGiamGia_GiamGiaMaGiamGia",
                table: "MaNhapGiamGia",
                column: "GiamGiaMaGiamGia");

            migrationBuilder.AddForeignKey(
                name: "FK_MaNhapGiamGia_GiamGia_GiamGiaMaGiamGia",
                table: "MaNhapGiamGia",
                column: "GiamGiaMaGiamGia",
                principalTable: "GiamGia",
                principalColumn: "MaGiamGia");
        }
    }
}
