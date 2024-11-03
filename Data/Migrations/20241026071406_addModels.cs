using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkthroughApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walkthrough",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Compliant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walkthrough", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walkthrough_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Walkthrough_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walkthrough_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walkthrough_DepartmentId",
                table: "Walkthrough",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Walkthrough_IdentityUserId",
                table: "Walkthrough",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Walkthrough_ProcedureId",
                table: "Walkthrough",
                column: "ProcedureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walkthrough");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Procedure");
        }
    }
}
