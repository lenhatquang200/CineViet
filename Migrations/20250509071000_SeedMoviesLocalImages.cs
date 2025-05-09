using Microsoft.EntityFrameworkCore.Migrations;

namespace CineViet.Migrations
{
    public partial class SeedMoviesLocalImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "Duration", "Year", "Rating", "Image" },
                values: new object[,]
                {
                    { 1, "Avengers: Endgame", "Hành động, Phiêu lưu", 181, 2023, 9.2, "/images/avengers.jpg" },
                    { 2, "Joker", "Tội phạm, Kịch tính", 122, 2023, 8.4, "/images/joker.jpg" },
                    { 3, "Parasite", "Hài kịch, Kịch tính", 132, 2023, 8.6, "/images/parasite.jpg" },
                    { 4, "The Batman", "Hành động, Tội phạm", 176, 2024, 7.9, "/images/batman.jpg" },
                    { 5, "Dune", "Phiêu lưu, Khoa học viễn tưởng", 155, 2024, 8.1, "/images/dune.jpg" },
                    { 6, "No Time to Die", "Hành động, Phiêu lưu", 163, 2024, 7.7, "/images/notimetodie.jpg" },
                    { 7, "Spider-Man: No Way Home", "Hành động, Phiêu lưu", 148, 2024, 8.3, "/images/spiderman.jpg" }
                }
            );
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 }
            );
        }
    }
}