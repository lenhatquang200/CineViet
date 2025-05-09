using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using CineViet.Models;

public class DashboardModel : PageModel
{
    private readonly AppDbContext _db;
    public int MovieCount { get; set; }
    public int CinemaCount { get; set; }
    public int ShowtimeCount { get; set; }
    public int CustomerCount { get; set; }
    public int BookingCount { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Cinema> Cinemas { get; set; }
    public List<Showtime> Showtimes { get; set; }
    public List<User> Customers { get; set; }
    public List<Booking> Bookings { get; set; }
    public DashboardModel(AppDbContext db) { _db = db; }
    public void OnGet()
    {
        MovieCount = _db.Movies.Count();
        CinemaCount = _db.Cinemas.Count();
        ShowtimeCount = _db.Showtimes.Count();
        CustomerCount = _db.Users.Count(u => !u.IsAdmin);
        BookingCount = _db.Bookings.Count();
        Movies = _db.Movies.OrderByDescending(m => m.Id).ToList();
        Cinemas = _db.Cinemas.OrderByDescending(c => c.Id).ToList();
        Showtimes = _db.Showtimes.Include(s => s.Movie).Include(s => s.Cinema).OrderByDescending(s => s.Id).ToList();
        Customers = _db.Users.Where(u => !u.IsAdmin).OrderByDescending(u => u.Id).ToList();
        Bookings = _db.Bookings.Include(b => b.Showtime).ThenInclude(s => s.Movie).Include(b => b.Showtime).ThenInclude(s => s.Cinema).OrderByDescending(b => b.Id).ToList();
    }
    public IActionResult OnPostAddMovie()
    {
        var name = Request.Form["Name"].ToString();
        var genre = Request.Form["Genre"].ToString();
        var duration = int.Parse(Request.Form["Duration"]);
        var year = int.Parse(Request.Form["Year"]);
        var rating = double.Parse(Request.Form["Rating"]);
        var status = Request.Form["Status"].ToString();
        var file = Request.Form.Files["ImageFile"];
        string fileName = null;
        if (file != null && file.Length > 0)
        {
            var uploads = Path.Combine("wwwroot", "uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{System.Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploads, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        var movie = new Movie
        {
            Name = name,
            Genre = genre,
            Duration = duration,
            Year = year,
            Rating = rating,
            Image = fileName != null ? "/uploads/" + fileName : "",
            Status = status
        };
        _db.Movies.Add(movie);
        _db.SaveChanges();
        return RedirectToPage(new { section = "movies" });
    }
    public IActionResult OnPostDeleteMovie(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "movies" });
    }
    public IActionResult OnPostAddCinema()
    {
        var name = Request.Form["Name"].ToString();
        var address = Request.Form["Address"].ToString();
        var cinema = new Cinema { Name = name, Address = address };
        _db.Cinemas.Add(cinema);
        _db.SaveChanges();
        return RedirectToPage(new { section = "cinemas" });
    }
    public IActionResult OnPostDeleteCinema(int id)
    {
        var cinema = _db.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema != null)
        {
            _db.Cinemas.Remove(cinema);
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "cinemas" });
    }
    public IActionResult OnPostAddShowtime()
    {
        var movieId = int.Parse(Request.Form["MovieId"]);
        var cinemaId = int.Parse(Request.Form["CinemaId"]);
        var time = DateTime.Parse(Request.Form["Time"]);
        var showtime = new Showtime { MovieId = movieId, CinemaId = cinemaId, Time = time };
        _db.Showtimes.Add(showtime);
        _db.SaveChanges();
        return RedirectToPage(new { section = "showtimes" });
    }
    public IActionResult OnPostDeleteShowtime(int id)
    {
        var showtime = _db.Showtimes.FirstOrDefault(s => s.Id == id);
        if (showtime != null)
        {
            _db.Showtimes.Remove(showtime);
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "showtimes" });
    }
    public IActionResult OnPostDeleteCustomer(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id && !u.IsAdmin);
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "customers" });
    }
    public IActionResult OnPostDeleteBooking(int id)
    {
        var booking = _db.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "bookings" });
    }
    public IActionResult OnPostEditMovie(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return RedirectToPage(new { section = "movies" });
        movie.Name = Request.Form["Name"];
        movie.Genre = Request.Form["Genre"];
        movie.Duration = int.Parse(Request.Form["Duration"]);
        movie.Year = int.Parse(Request.Form["Year"]);
        movie.Rating = double.Parse(Request.Form["Rating"]);
        movie.Status = Request.Form["Status"];
        var file = Request.Form.Files["ImageFile"];
        if (file != null && file.Length > 0)
        {
            var uploads = Path.Combine("wwwroot", "uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{System.Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploads, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            movie.Image = "/uploads/" + fileName;
        }
        _db.SaveChanges();
        return RedirectToPage(new { section = "movies" });
    }
    public IActionResult OnPostEditCinema(int id)
    {
        var cinema = _db.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return RedirectToPage(new { section = "cinemas" });
        cinema.Name = Request.Form["Name"];
        cinema.Address = Request.Form["Address"];
        _db.SaveChanges();
        return RedirectToPage(new { section = "cinemas" });
    }
    public IActionResult OnPostEditShowtime(int id)
    {
        var showtime = _db.Showtimes.FirstOrDefault(s => s.Id == id);
        if (showtime == null) return RedirectToPage(new { section = "showtimes" });
        showtime.MovieId = int.Parse(Request.Form["MovieId"]);
        showtime.CinemaId = int.Parse(Request.Form["CinemaId"]);
        showtime.Time = DateTime.Parse(Request.Form["Time"]);
        _db.SaveChanges();
        return RedirectToPage(new { section = "showtimes" });
    }
    public IActionResult OnPostEditCustomer(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id && !u.IsAdmin);
        if (user == null) return RedirectToPage(new { section = "customers" });
        user.FullName = Request.Form["FullName"];
        user.Email = Request.Form["Email"];
        user.Phone = Request.Form["Phone"];
        _db.SaveChanges();
        return RedirectToPage(new { section = "customers" });
    }
    public IActionResult OnPostUpdateBookingStatus(int id)
    {
        var booking = _db.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            booking.Status = Request.Form["Status"];
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "bookings" });
    }
    public IActionResult OnPostPrintTicket(int id)
    {
        var booking = _db.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            booking.Status = "printed";
            _db.SaveChanges();
        }
        return RedirectToPage(new { section = "bookings" });
    }
} 