using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Annex_ReferenceFolderTagID",
                table: "Annex_Annexs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annex_ReferenceFolderTagID",
                table: "Annex_Annexs");
        }
    }
}
