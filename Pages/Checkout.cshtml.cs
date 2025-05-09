using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System;
using CineViet.Models;

public class CheckoutModel : PageModel
{
    private readonly AppDbContext _db;
    public CheckoutModel(AppDbContext db) { _db = db; }

    [BindProperty]
    public int ShowtimeId { get; set; }
    [BindProperty]
    public List<string> Seats { get; set; } = new List<string>();
    [BindProperty]
    public bool Confirm { get; set; }
    [BindProperty]
    public string ContactName { get; set; }
    [BindProperty]
    public string ContactEmail { get; set; }
    [BindProperty]
    public string ContactPhone { get; set; }

    public Movie Movie { get; set; }
    public Cinema Cinema { get; set; }
    public Showtime Showtime { get; set; }
    public int StandardPrice = 90000;
    public int VipPrice = 120000;
    public bool HasVip => Seats.Any(s => s.StartsWith("D"));
    public int Total => Seats.Sum(s => s.StartsWith("D") ? VipPrice : StandardPrice);
    public string Type => HasVip ? "VIP" : "Thường";
    public bool IsValid => Movie != null && Cinema != null && Showtime != null && Seats.Count > 0;

    public void OnGet()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                ContactName = user.FullName;
                ContactEmail = user.Email;
                ContactPhone = user.Phone;
            }
        }
    }

    public IActionResult OnPost()
    {
        Showtime = _db.Showtimes.FirstOrDefault(s => s.Id == ShowtimeId);
        if (Showtime != null)
        {
            Movie = _db.Movies.FirstOrDefault(m => m.Id == Showtime.MovieId);
            Cinema = _db.Cinemas.FirstOrDefault(c => c.Id == Showtime.CinemaId);
        }
        if (!IsValid)
        {
            SetUserContactIfEmpty();
            return Redirect($"/BookTicket?showtimeId={ShowtimeId}&error=1");
        }
        if (Confirm)
        {
            var customerName = Request.Form["ContactName"].ToString();
            var email = Request.Form["ContactEmail"].ToString();
            var phone = Request.Form["ContactPhone"].ToString();
            var booking = new Booking
            {
                CustomerName = customerName,
                Email = email,
                Phone = phone,
                ShowtimeId = ShowtimeId,
                Seats = string.Join(",", Seats),
                TotalPrice = Total,
                BookingTime = DateTime.Now,
                Status = "pending"
            };
            _db.Bookings.Add(booking);
            _db.SaveChanges();
            return Redirect("/?success=1");
        }
        SetUserContactIfEmpty();
        return Page();
    }

    private void SetUserContactIfEmpty()
    {
        if (string.IsNullOrEmpty(ContactName) || string.IsNullOrEmpty(ContactEmail) || string.IsNullOrEmpty(ContactPhone))
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                var user = _db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    if (string.IsNullOrEmpty(ContactName)) ContactName = user.FullName;
                    if (string.IsNullOrEmpty(ContactEmail)) ContactEmail = user.Email;
                    if (string.IsNullOrEmpty(ContactPhone)) ContactPhone = user.Phone;
                }
            }
        }
    }
} 