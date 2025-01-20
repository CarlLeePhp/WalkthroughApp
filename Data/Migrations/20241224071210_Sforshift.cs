using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkthroughApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sforshift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shift",
                table: "Walkthrough",
                newName: "Shift");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shift",
                table: "Walkthrough",
                newName: "shift");
        }
    }
}
