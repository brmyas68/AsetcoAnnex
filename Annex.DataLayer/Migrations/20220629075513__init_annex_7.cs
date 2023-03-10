using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnnexSetting_Dec",
                table: "Annex_AnnexSetting",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annex_Annexs_Annex_AnnexSettingID",
                table: "Annex_Annexs",
                column: "Annex_AnnexSettingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Annex_Annexs_Annex_AnnexSetting_Annex_AnnexSettingID",
                table: "Annex_Annexs",
                column: "Annex_AnnexSettingID",
                principalTable: "Annex_AnnexSetting",
                principalColumn: "AnnexSetting_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annex_Annexs_Annex_AnnexSetting_Annex_AnnexSettingID",
                table: "Annex_Annexs");

            migrationBuilder.DropIndex(
                name: "IX_Annex_Annexs_Annex_AnnexSettingID",
                table: "Annex_Annexs");

            migrationBuilder.DropColumn(
                name: "AnnexSetting_Dec",
                table: "Annex_AnnexSetting");
        }
    }
}
