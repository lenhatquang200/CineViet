using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class SeedFullData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "123 Nguyễn Văn Linh, Q7", "CineViet Quận 7" },
                    { 2, "45 Lê Lợi, Q1", "CineViet Quận 1" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Duration", "Genre", "Image", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, 181, "Hành động, Phiêu lưu", "https://image.tmdb.org/t/p/w500/or06FN3Dka5tukK1e9sl16pB3iy.jpg", "Avengers: Endgame", 9.1999999999999993, 2023 },
                    { 2, 122, "Tội phạm, Kịch tính", "https://image.tmdb.org/t/p/w500/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg", "Joker", 8.4000000000000004, 2023 },
                    { 3, 132, "Hài kịch, Kịch tính", "https://image.tmdb.org/t/p/w500/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg", "Parasite", 8.5999999999999996, 2023 },
                    { 4, 176, "Hành động, Tội phạm", "https://image.tmdb.org/t/p/w500/74xTEgt7R36Fpooo50r9T25onhq.jpg", "The Batman", 7.9000000000000004, 2024 },
                    { 5, 155, "Phiêu lưu, Khoa học viễn tưởng", "https://image.tmdb.org/t/p/w500/d5NXSklXo0qyIYkgV94XAgMIckC.jpg", "Dune", 8.0999999999999996, 2024 },
                    { 6, 163, "Hành động, Phiêu lưu", "https://image.tmdb.org/t/p/w500/iUgygt3fscRoKWCV1d0C7FbM9TP.jpg", "No Time to Die", 7.7000000000000002, 2024 },
                    { 7, 148, "Hành động, Phiêu lưu", "https://image.tmdb.org/t/p/w500/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg", "Spider-Man: No Way Home", 8.3000000000000007, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaId", "IsVip", "Number", "Row" },
                values: new object[,]
                {
                    { 1, 1, false, 1, "A" },
                    { 2, 1, false, 2, "A" },
                    { 3, 1, false, 3, "A" },
                    { 4, 1, false, 4, "A" },
                    { 5, 1, false, 5, "A" },
                    { 6, 1, false, 6, "A" },
                    { 7, 1, false, 7, "A" },
                    { 8, 1, false, 8, "A" },
                    { 9, 1, false, 1, "B" },
                    { 10, 1, false, 2, "B" },
                    { 11, 1, false, 3, "B" },
                    { 12, 1, false, 4, "B" },
                    { 13, 1, false, 5, "B" },
                    { 14, 1, false, 6, "B" },
                    { 15, 1, false, 7, "B" },
                    { 16, 1, false, 8, "B" },
                    { 17, 1, false, 1, "C" },
                    { 18, 1, false, 2, "C" },
                    { 19, 1, false, 3, "C" },
                    { 20, 1, false, 4, "C" },
                    { 21, 1, false, 5, "C" },
                    { 22, 1, false, 6, "C" },
                    { 23, 1, false, 7, "C" },
                    { 24, 1, false, 8, "C" },
                    { 25, 1, true, 1, "D" },
                    { 26, 1, true, 2, "D" },
                    { 27, 1, true, 3, "D" },
                    { 28, 1, true, 4, "D" },
                    { 29, 1, true, 5, "D" },
                    { 30, 1, true, 6, "D" },
                    { 31, 1, true, 7, "D" },
                    { 32, 1, true, 8, "D" },
                    { 33, 1, false, 1, "E" },
                    { 34, 1, false, 2, "E" },
                    { 35, 1, false, 3, "E" },
                    { 36, 1, false, 4, "E" },
                    { 37, 1, false, 5, "E" },
                    { 38, 1, false, 6, "E" },
                    { 39, 1, false, 7, "E" },
                    { 40, 1, false, 8, "E" },
                    { 41, 2, false, 1, "A" },
                    { 42, 2, false, 2, "A" },
                    { 43, 2, false, 3, "A" },
                    { 44, 2, false, 4, "A" },
                    { 45, 2, false, 5, "A" },
                    { 46, 2, false, 6, "A" },
                    { 47, 2, false, 7, "A" },
                    { 48, 2, false, 8, "A" },
                    { 49, 2, false, 1, "B" },
                    { 50, 2, false, 2, "B" },
                    { 51, 2, false, 3, "B" },
                    { 52, 2, false, 4, "B" },
                    { 53, 2, false, 5, "B" },
                    { 54, 2, false, 6, "B" },
                    { 55, 2, false, 7, "B" },
                    { 56, 2, false, 8, "B" },
                    { 57, 2, false, 1, "C" },
                    { 58, 2, false, 2, "C" },
                    { 59, 2, false, 3, "C" },
                    { 60, 2, false, 4, "C" },
                    { 61, 2, false, 5, "C" },
                    { 62, 2, false, 6, "C" },
                    { 63, 2, false, 7, "C" },
                    { 64, 2, false, 8, "C" },
                    { 65, 2, true, 1, "D" },
                    { 66, 2, true, 2, "D" },
                    { 67, 2, true, 3, "D" },
                    { 68, 2, true, 4, "D" },
                    { 69, 2, true, 5, "D" },
                    { 70, 2, true, 6, "D" },
                    { 71, 2, true, 7, "D" },
                    { 72, 2, true, 8, "D" },
                    { 73, 2, false, 1, "E" },
                    { 74, 2, false, 2, "E" },
                    { 75, 2, false, 3, "E" },
                    { 76, 2, false, 4, "E" },
                    { 77, 2, false, 5, "E" },
                    { 78, 2, false, 6, "E" },
                    { 79, 2, false, 7, "E" },
                    { 80, 2, false, 8, "E" }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "CinemaId", "MovieId", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, new DateTime(2025, 5, 10, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 1, new DateTime(2025, 5, 10, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 2, new DateTime(2025, 5, 10, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 2, new DateTime(2025, 5, 10, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 3, new DateTime(2025, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 1, new DateTime(2025, 5, 10, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
