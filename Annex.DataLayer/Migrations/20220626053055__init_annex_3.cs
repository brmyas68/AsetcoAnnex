using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annex_ReferenceFolderTagID",
                table: "Annex_Annexs");

            migrationBuilder.AddColumn<string>(
                name: "Annex_Path",
                table: "Annex_Annexs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annex_ReferenceFolderName",
                table: "Annex_Annexs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annex_Path",
                table: "Annex_Annexs");

            migrationBuilder.DropColumn(
                name: "Annex_ReferenceFolderName",
                table: "Annex_Annexs");

            migrationBuilder.AddColumn<int>(
                name: "Annex_ReferenceFolderTagID",
                table: "Annex_Annexs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
