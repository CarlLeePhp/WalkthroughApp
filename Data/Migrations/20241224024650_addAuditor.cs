using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkthroughApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAuditor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditorId",
                table: "Walkthrough",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Auditor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walkthrough_AuditorId",
                table: "Walkthrough",
                column: "AuditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walkthrough_Auditor_AuditorId",
                table: "Walkthrough",
                column: "AuditorId",
                principalTable: "Auditor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walkthrough_Auditor_AuditorId",
                table: "Walkthrough");

            migrationBuilder.DropTable(
                name: "Auditor");

            migrationBuilder.DropIndex(
                name: "IX_Walkthrough_AuditorId",
                table: "Walkthrough");

            migrationBuilder.DropColumn(
                name: "AuditorId",
                table: "Walkthrough");
        }
    }
}
