using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class InsertMoviesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Movies");
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "Duration", "Year", "Rating", "Image", "Description", "Cast", "Director" },
                values: new object[,]
                {
                    { 1, "Avengers: Endgame", "Hành động, Phiêu lưu", 181, 2023, 9.2, "/images/avengers.jpg", "Sau các sự kiện tàn khốc của Infinity War, các Avengers tập hợp để đảo ngược hành động của Thanos.", "Robert Downey Jr., Chris Evans, Mark Ruffalo", "Anthony Russo, Joe Russo" },
                    { 2, "Joker", "Tội phạm, Kịch tính", 122, 2023, 8.4, "/images/joker.jpg", "Một người đàn ông bị xã hội ruồng bỏ trở thành kẻ thù nguy hiểm nhất của Gotham.", "Joaquin Phoenix, Robert De Niro", "Todd Phillips" },
                    { 3, "Parasite", "Hài kịch, Kịch tính", 132, 2023, 8.6, "/images/parasite.jpg", "Gia đình nghèo xâm nhập vào gia đình giàu có bằng những mưu mẹo tinh vi.", "Song Kang-ho, Lee Sun-kyun", "Bong Joon-ho" },
                    { 4, "The Batman", "Hành động, Tội phạm", 176, 2024, 7.9, "/images/batman.jpg", "Bruce Wayne đối mặt với những bí ẩn mới và kẻ thù nguy hiểm ở Gotham.", "Robert Pattinson, Zoë Kravitz", "Matt Reeves" },
                    { 5, "Dune", "Phiêu lưu, Khoa học viễn tưởng", 155, 2024, 8.1, "/images/dune.jpg", "Paul Atreides dẫn dắt gia tộc của mình vào cuộc chiến sinh tồn trên hành tinh sa mạc.", "Timothée Chalamet, Rebecca Ferguson", "Denis Villeneuve" },
                    { 6, "No Time to Die", "Hành động, Phiêu lưu", 163, 2024, 7.7, "/images/notimetodie.jpg", "James Bond trở lại để đối đầu với một kẻ thù mới sở hữu công nghệ nguy hiểm.", "Daniel Craig, Rami Malek", "Cary Joji Fukunaga" },
                    { 7, "Spider-Man: No Way Home", "Hành động, Phiêu lưu", 148, 2024, 8.3, "/images/spiderman.jpg", "Peter Parker đối mặt với đa vũ trụ và những kẻ thù từ các thế giới khác nhau.", "Tom Holland, Zendaya", "Jon Watts" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Movies");
        }
    }
}
