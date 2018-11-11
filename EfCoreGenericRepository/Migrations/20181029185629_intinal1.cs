using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Migrations
{
    public partial class intinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESS-Requests");

            migrationBuilder.CreateTable(
                name: "ESS_AmendmentReasons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmendReasonAr = table.Column<string>(nullable: true),
                    AmendReasonEn = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_AmendmentReasons", x => x.ID);
                });

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
                    IsDelegate = table.Column<bool>(nullable: true),
                    IsDelegateApprove = table.Column<bool>(nullable: true),
                    RequestTypeID = table.Column<int>(nullable: true),
                    ShabId = table.Column<long>(nullable: false),
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
                    DetailsURL = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    RequestGroupID = table.Column<int>(nullable: true),
                    RequestUrl = table.Column<string>(nullable: true),
                    Requests = table.Column<string>(nullable: true),
                    icons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_Requests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ESS_Amendment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmendmentReasonId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DocumentID = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    MonthDate = table.Column<int>(nullable: true),
                    MonthDay = table.Column<int>(nullable: true),
                    MonthYear = table.Column<int>(nullable: true),
                    RequestID = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    TimeIn = table.Column<string>(nullable: true),
                    TimeOut = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS_Amendment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ESS_Amendment_ESS_AmendmentReasons_AmendmentReasonId",
                        column: x => x.AmendmentReasonId,
                        principalTable: "ESS_AmendmentReasons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESS_Amendment_ESS_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "ESS_Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESS_Amendment_ESS_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "ESS_Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_AmendmentReasonId",
                table: "ESS_Amendment",
                column: "AmendmentReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_DocumentID",
                table: "ESS_Amendment",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_ESS_Amendment_RequestID",
                table: "ESS_Amendment",
                column: "RequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESS_Amendment");

            migrationBuilder.DropTable(
                name: "ESS_AmendmentReasons");

            migrationBuilder.DropTable(
                name: "ESS_Documents");

            migrationBuilder.DropTable(
                name: "ESS_Requests");

            migrationBuilder.CreateTable(
                name: "ESS-Requests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(nullable: true),
                    DetailsURL = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    RequestGroupID = table.Column<int>(nullable: true),
                    RequestUrl = table.Column<string>(nullable: true),
                    Requests = table.Column<string>(nullable: true),
                    icons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESS-Requests", x => x.id);
                });
        }
    }
}
