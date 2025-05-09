using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CineViet.Models;

public class PrintTicketModel : PageModel
{
    private readonly AppDbContext _db;
    public Booking Booking { get; set; }
    public PrintTicketModel(AppDbContext db) { _db = db; }
    public IActionResult OnGet(int id)
    {
        Booking = _db.Bookings.Include(b => b.Showtime).ThenInclude(s => s.Movie).Include(b => b.Showtime).ThenInclude(s => s.Cinema).FirstOrDefault(b => b.Id == id);
        if (Booking == null) return NotFound();
        return Page();
    }
    public IActionResult OnPost(int id)
    {
        var booking = _db.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            booking.Status = "printed";
            _db.SaveChanges();
        }
        return RedirectToPage(new { id });
    }
} 