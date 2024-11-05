using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_GS.Migrations
{
    /// <inheritdoc />
    public partial class AddDuLieu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "MaNhapGiamGia",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "MaNhapGiamGia");
        }
    }
}
