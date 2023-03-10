using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annex_Annexs",
                columns: table => new
                {
                    Annex_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annex_FileNamePhysicy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Annex_FileNameLogic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Annex_ReferenceID = table.Column<int>(type: "int", nullable: false),
                    Annex_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Annex_AnnexSettingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annex_Annexs", x => x.Annex_ID);
                });

            migrationBuilder.CreateTable(
                name: "Annex_AnnexSetting",
                columns: table => new
                {
                    AnnexSetting_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnexSetting_TenantID = table.Column<int>(type: "int", nullable: false),
                    AnnexSetting_SystemTagID = table.Column<int>(type: "int", nullable: false),
                    AnnexSetting_TagsknowledgeID = table.Column<int>(type: "int", nullable: false),
                    AnnexSetting_ReferenceComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annex_AnnexSetting", x => x.AnnexSetting_ID);
                });

            migrationBuilder.CreateIndex(
                name: "Index_AnnexRefSetting",
                table: "Annex_Annexs",
                columns: new[] { "Annex_ReferenceID", "Annex_AnnexSettingID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annex_Annexs");

            migrationBuilder.DropTable(
                name: "Annex_AnnexSetting");
        }
    }
}
