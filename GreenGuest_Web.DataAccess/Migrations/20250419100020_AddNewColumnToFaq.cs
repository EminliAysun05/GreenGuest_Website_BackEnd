using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGuest_Web.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToFaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FaqItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FaqItems");
        }
    }
}
