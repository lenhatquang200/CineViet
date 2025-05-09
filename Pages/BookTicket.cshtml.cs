using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Collections.Generic;
using CineViet.Models;

public class BookTicketModel : PageModel
{
    private readonly AppDbContext _db;
    [BindProperty]
    public string MovieName { get; set; }
    [BindProperty]
    public DateTime ShowTime { get; set; }
    [BindProperty]
    public int Quantity { get; set; }
    [BindProperty]
    public string CustomerName { get; set; }
    public string? Message { get; set; }
    public Movie Movie { get; set; }
    public Cinema Cinema { get; set; }
    public Showtime Showtime { get; set; }
    public List<Seat> Seats { get; set; }
    public List<string> SoldSeats { get; set; } = new(); // Tạm thời để trống
    public BookTicketModel(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult OnGet(int showtimeId)
    {
        Showtime = _db.Showtimes.FirstOrDefault(s => s.Id == showtimeId);
        if (Showtime == null) return Redirect("/Movies");
        Movie = _db.Movies.FirstOrDefault(m => m.Id == Showtime.MovieId);
        Cinema = _db.Cinemas.FirstOrDefault(c => c.Id == Showtime.CinemaId);
        Seats = _db.Seats.Where(s => s.CinemaId == Cinema.Id).OrderBy(s => s.Row).ThenBy(s => s.Number).ToList();
        if (Movie == null || Cinema == null) return Redirect("/Movies");
        // TODO: Lấy danh sách ghế đã bán từ bảng Booking nếu cần
        return Page();
    }
    public void OnPost()
    {
        Message = $"Đặt vé thành công cho {CustomerName} - Phim: {MovieName}, Suất: {ShowTime}, Số lượng: {Quantity}";
    }
} 