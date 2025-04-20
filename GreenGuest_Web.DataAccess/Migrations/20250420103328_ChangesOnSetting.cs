using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGuest_Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Settings",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Settings",
                newName: "isDeleted");
        }
    }
}
