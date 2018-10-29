using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Migrations
{
    public partial class intinal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsURL",
                table: "ESS_Requests");

            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "ESS_Requests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailsURL",
                table: "ESS_Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "ESS_Requests",
                nullable: true);
        }
    }
}
