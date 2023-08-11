using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingMert.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Events",
                newName: "Tarih");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "Saat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "Events",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Saat",
                table: "Events",
                newName: "Date");
        }
    }
}
