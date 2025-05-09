using Microsoft.EntityFrameworkCore;

namespace CineViet.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Avengers: Endgame", Genre = "Hành động, Phiêu lưu", Duration = 181, Year = 2023, Rating = 9.2, Image = "/images/avengers.jpg", Status = "now" },
                new Movie { Id = 2, Name = "Joker", Genre = "Tội phạm, Kịch tính", Duration = 122, Year = 2023, Rating = 8.4, Image = "/images/joker.jpg", Status = "now" },
                new Movie { Id = 3, Name = "Parasite", Genre = "Hài kịch, Kịch tính", Duration = 132, Year = 2023, Rating = 8.6, Image = "/images/parasite.jpg", Status = "now" },
                new Movie { Id = 4, Name = "The Batman", Genre = "Hành động, Tội phạm", Duration = 176, Year = 2024, Rating = 7.9, Image = "/images/batman.jpg", Status = "coming" },
                new Movie { Id = 5, Name = "Dune", Genre = "Phiêu lưu, Khoa học viễn tưởng", Duration = 155, Year = 2024, Rating = 8.1, Image = "/images/dune.jpg", Status = "coming" },
                new Movie { Id = 6, Name = "No Time to Die", Genre = "Hành động, Phiêu lưu", Duration = 163, Year = 2024, Rating = 7.7, Image = "/images/notimetodie.jpg", Status = "coming" },
                new Movie { Id = 7, Name = "Spider-Man: No Way Home", Genre = "Hành động, Phiêu lưu", Duration = 148, Year = 2024, Rating = 8.3, Image = "/images/spiderman.jpg", Status = "coming" }
            );
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema { Id = 1, Name = "CineViet Quận 7", Address = "123 Nguyễn Văn Linh, Q7" },
                new Cinema { Id = 2, Name = "CineViet Quận 1", Address = "45 Lê Lợi, Q1" }
            );
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime { Id = 1, MovieId = 1, CinemaId = 1, Time = new DateTime(2025, 5, 10, 10, 0, 0) },
                new Showtime { Id = 2, MovieId = 1, CinemaId = 1, Time = new DateTime(2025, 5, 10, 13, 0, 0) },
                new Showtime { Id = 3, MovieId = 1, CinemaId = 2, Time = new DateTime(2025, 5, 10, 15, 0, 0) },
                new Showtime { Id = 4, MovieId = 2, CinemaId = 1, Time = new DateTime(2025, 5, 10, 11, 0, 0) },
                new Showtime { Id = 5, MovieId = 2, CinemaId = 2, Time = new DateTime(2025, 5, 10, 16, 0, 0) },
                new Showtime { Id = 6, MovieId = 3, CinemaId = 1, Time = new DateTime(2025, 5, 10, 12, 0, 0) },
                new Showtime { Id = 7, MovieId = 1, CinemaId = 1, Time = new DateTime(2025, 5, 10, 16, 0, 0) }
            );
            // Seed ghế cho mỗi rạp: 5 hàng (A-E), 8 ghế/hàng, D là VIP
            var seats = new List<Seat>();
            int seatId = 1;
            var rows = new[] { "A", "B", "C", "D", "E" };
            for (int cinemaId = 1; cinemaId <= 2; cinemaId++)
            {
                foreach (var row in rows)
                {
                    for (int num = 1; num <= 8; num++)
                    {
                        seats.Add(new Seat { Id = seatId++, Row = row, Number = num, IsVip = row == "D", CinemaId = cinemaId });
                    }
                }
            }
            modelBuilder.Entity<Seat>().HasData(seats);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 100,
                    FullName = "Admin",
                    Phone = "0123456789",
                    Email = "admin@cinema.com",
                    PasswordHash = "$2a$11$6G3EHGTWDgvXHA.CnuLjE.cDnirSDmIa2FawDzE8dNVREadwMPWJW",
                    // 123
                    CreatedAt = DateTime.UtcNow,
                    IsAdmin = true
                }
            );
        }
    }
}