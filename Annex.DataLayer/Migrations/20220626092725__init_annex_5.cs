﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    public partial class _init_annex_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Annex_CreatedDate",
                table: "Annex_Annexs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annex_CreatedDate",
                table: "Annex_Annexs");
        }
    }
}
