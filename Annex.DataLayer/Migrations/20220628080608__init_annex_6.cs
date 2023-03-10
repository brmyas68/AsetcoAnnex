using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Annex_FileExtension",
                table: "Annex_Annexs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Annex_IsDefault",
                table: "Annex_Annexs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annex_FileExtension",
                table: "Annex_Annexs");

            migrationBuilder.DropColumn(
                name: "Annex_IsDefault",
                table: "Annex_Annexs");
        }
    }
}
