using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class AddTrangThaiToGiamGiaAndCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "GiamGia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "Combos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB001",
                column: "TrangThai",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB002",
                column: "TrangThai",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB003",
                column: "TrangThai",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP001",
                column: "TrangThai",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GiamGia",
                keyColumn: "MaGiamGia",
                keyValue: "CP002",
                column: "TrangThai",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "GiamGia");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Combos");
        }
    }
}
