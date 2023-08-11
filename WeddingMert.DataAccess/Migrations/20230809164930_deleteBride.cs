using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingMert.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteBride : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bride",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Groom",
                table: "Abouts",
                newName: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Abouts",
                newName: "Groom");

            migrationBuilder.AddColumn<string>(
                name: "Bride",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
