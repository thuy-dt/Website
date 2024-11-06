using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class anh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anh",
                table: "Combos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB001",
                column: "Anh",
                value: "wwwroot/img/AnhCombo/z5959105369727_62f7dd6336f7577e1dd7ee873b52f574.jpg");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB002",
                column: "Anh",
                value: "wwwroot/img/AnhCombo/z5959105369727_62f7dd6336f7577e1dd7ee873b52f574.jpg");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "MaCombo",
                keyValue: "CB003",
                column: "Anh",
                value: "wwwroot/img/AnhCombo/z5959105369727_62f7dd6336f7577e1dd7ee873b52f574.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anh",
                table: "Combos");
        }
    }
}
