using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Migrations
{
    public partial class inintal6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.DropIndex(
                name: "IX_ESS_Amendment_ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "ESS_RequestType");

            migrationBuilder.DropColumn(
                name: "ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.RenameColumn(
                name: "DocumentID",
                table: "ESS_Amendment",
                newName: "RequestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_RequestTypeID",
                table: "ESS_Amendment",
                column: "RequestTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_RequestTypeID",
                table: "ESS_Amendment",
                column: "RequestTypeID",
                principalTable: "ESS_RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_RequestTypeID",
                table: "ESS_Amendment");

            migrationBuilder.DropIndex(
                name: "IX_ESS_Amendment_RequestTypeID",
                table: "ESS_Amendment");

            migrationBuilder.RenameColumn(
                name: "RequestTypeID",
                table: "ESS_Amendment",
                newName: "DocumentID");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "ESS_RequestType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ESS_RequestTypeid",
                table: "ESS_Amendment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_ESS_RequestTypeid",
                table: "ESS_Amendment",
                column: "ESS_RequestTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_ESS_RequestTypeid",
                table: "ESS_Amendment",
                column: "ESS_RequestTypeid",
                principalTable: "ESS_RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
