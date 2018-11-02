using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Migrations
{
    public partial class intital9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ESS_Amendment_ESS_RequestType_RequestTypeID",
            //    table: "ESS_Amendment");

            //migrationBuilder.DropIndex(
            //    name: "IX_ESS_Amendment_RequestTypeID",
            //    table: "ESS_Amendment");

            migrationBuilder.DropColumn(
                name: "RequestTypeID",
                table: "ESS_Amendment");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ESS_Amendment");

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Request_RequestTypeID",
                table: "ESS_Request",
                column: "RequestTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Request_ESS_RequestType_RequestTypeID",
                table: "ESS_Request",
                column: "RequestTypeID",
                principalTable: "ESS_RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Request_ESS_RequestType_RequestTypeID",
                table: "ESS_Request");

            migrationBuilder.DropIndex(
                name: "IX_ESS_Request_RequestTypeID",
                table: "ESS_Request");

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeID",
                table: "ESS_Amendment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "ESS_Amendment",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ESS_Amendment_RequestTypeID",
            //    table: "ESS_Amendment",
            //    column: "RequestTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_RequestTypeID",
                table: "ESS_Amendment",
                column: "RequestTypeID",
                principalTable: "ESS_RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
