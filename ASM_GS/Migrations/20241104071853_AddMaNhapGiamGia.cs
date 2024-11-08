using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class AddMaNhapGiamGia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenGiamGia",
                table: "GiamGia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongMaNhapToiDa",
                table: "GiamGia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TenCombo",
                table: "Combos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MaNhapGiamGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiamGiaMaGiamGia = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaNhapGiamGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaNhapGiamGia_GiamGia_GiamGiaMaGiamGia",
                        column: x => x.GiamGiaMaGiamGia,
                        principalTable: "GiamGia",
                        principalColumn: "MaGiamGia");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaNhapGiamGia");

            migrationBuilder.DropColumn(
                name: "SoLuongMaNhapToiDa",
                table: "GiamGia");

            migrationBuilder.AlterColumn<string>(
                name: "TenGiamGia",
                table: "GiamGia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TenCombo",
                table: "Combos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
