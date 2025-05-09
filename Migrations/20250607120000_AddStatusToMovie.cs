using Microsoft.EntityFrameworkCore.Migrations;

namespace CineViet.Migrations
{
    public partial class AddStatusToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "now");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Movies");
        }
    }
}