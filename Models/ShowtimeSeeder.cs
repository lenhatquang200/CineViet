using System;
using System.Linq;

namespace CineViet.Models
{
    public static class ShowtimeSeeder
    {
        public static void Seed(AppDbContext db)
        {
            var today = DateTime.Today;
            var end = today.AddDays(14);
            var movies = db.Movies.Where(m => m.Status == "now").ToList();
            var cinemas = db.Cinemas.ToList();
            var random = new Random();
            int showtimeId = db.Showtimes.Any() ? db.Showtimes.Max(s => s.Id) + 1 : 1;
            foreach (var movie in movies)
            {
                foreach (var cinema in cinemas)
                {
                    for (var date = today; date < end; date = date.AddDays(1))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var hour = 9 + i * 3 + random.Next(0, 2); // 9h, 12h, 15h, 18h, 21h +/- 0-1h
                            var time = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                            if (!db.Showtimes.Any(s => s.MovieId == movie.Id && s.CinemaId == cinema.Id && s.Time == time))
                            {
                                db.Showtimes.Add(new Showtime
                                {
                                    MovieId = movie.Id,
                                    CinemaId = cinema.Id,
                                    Time = time
                                });
                            }
                        }
                    }
                }
            }
            db.SaveChanges();
        }
    }
}