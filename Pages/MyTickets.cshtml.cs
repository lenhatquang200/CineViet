using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CineViet.Models;

public class MyTicketsModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Booking> Bookings { get; set; }
    public MyTicketsModel(AppDbContext db) { _db = db; }
    public void OnGet()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            Bookings = null;
            return;
        }
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            Bookings = null;
            return;
        }
        Bookings = _db.Bookings
            .Include(b => b.Showtime)
            .ThenInclude(s => s.Movie)
            .Include(b => b.Showtime)
            .ThenInclude(s => s.Cinema)
            .Where(b => b.Email == user.Email)
            .OrderByDescending(b => b.BookingTime)
            .ToList();
    }
} 