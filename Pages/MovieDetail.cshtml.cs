using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using CineViet.Models;

public class MovieDetailModel : PageModel
{
    private readonly AppDbContext _db;
    public Movie Movie { get; set; }
    public List<Showtime> Showtimes { get; set; }
    public MovieDetailModel(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult OnGet(int id)
    {
        Movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (Movie == null) return NotFound();
        if (Movie.Status == "now")
        {
            var today = DateTime.Today;
            var end = today.AddDays(7);
            Showtimes = _db.Showtimes.Where(s => s.MovieId == id && s.Time >= today && s.Time < end).ToList();
        }
        else
        {
            Showtimes = null;
        }
        return Page();
    }
} 