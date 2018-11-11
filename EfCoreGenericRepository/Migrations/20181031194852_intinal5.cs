using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Migrations
{
    public partial class intinal5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_Documents_DocumentID",
                table: "ESS_Amendment");

            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_Requests_RequestID",
                table: "ESS_Amendment");

            migrationBuilder.DropTable(
                name: "ESS_Documents");

            migrationBuilder.DropTable(
                name: "ESS_Requests");

            migrationBuilder.DropIndex(
                name: "IX_ESS_Amendment_DocumentID",
                table: "ESS_Amendment");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ESS_Amendment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ESS_Amendment",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ESS_RequestTypeid",
                table: "ESS_Amendment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ESS_Request",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DelegateFromID = table.Column<long>(nullable: true),
                    DelegateToID = table.Column<long>(nullable: true),
                    EmployeeID = table.Column<long>(nullable: false),
                    IsDelegate = table.Column<bool>(nullable: true),
                    IsDelegateApprove = table.Column<bool>(nullable: true),
                    RequestTypeID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_Request", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESS_RequestType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControllerName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    RequestGroupID = table.Column<int>(nullable: true),
                    RequestName = table.Column<string>(nullable: true),
                    icons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_RequestType", x => x.id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_Request_RequestID",
                table: "ESS_Amendment",
                column: "RequestID",
                principalTable: "ESS_Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_RequestType_ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.DropForeignKey(
                name: "FK_ESS_Amendment_ESS_Request_RequestID",
                table: "ESS_Amendment");

            migrationBuilder.DropTable(
                name: "ESS_Request");

            migrationBuilder.DropTable(
                name: "ESS_RequestType");

            migrationBuilder.DropIndex(
                name: "IX_ESS_Amendment_ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.DropColumn(
                name: "ESS_RequestTypeid",
                table: "ESS_Amendment");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ESS_Amendment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ESS_Amendment",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ESS_Documents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DelegateFromID = table.Column<long>(nullable: true),
                    DelegateToID = table.Column<long>(nullable: true),
                    EmployeeID = table.Column<long>(nullable: false),
                    IsDelegate = table.Column<bool>(nullable: true),
                    IsDelegateApprove = table.Column<bool>(nullable: true),
                    RequestTypeID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_Documents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESS_Requests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControllerName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    RequestGroupID = table.Column<int>(nullable: true),
                    RequestName = table.Column<string>(nullable: true),
                    icons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_Requests", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_DocumentID",
                table: "ESS_Amendment",
                column: "DocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_Documents_DocumentID",
                table: "ESS_Amendment",
                column: "DocumentID",
                principalTable: "ESS_Documents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESS_Amendment_ESS_Requests_RequestID",
                table: "ESS_Amendment",
                column: "RequestID",
                principalTable: "ESS_Requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
