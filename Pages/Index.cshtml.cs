using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using CineViet.Models;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Movie> NowShowing { get; set; }
    public List<Movie> ComingSoon { get; set; }
    public Movie HeroMovie { get; set; }
    public IndexModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        var allNowShowing = _db.Movies.Where(m => m.Status == "now").OrderByDescending(m => m.Id).ToList();
        var allComingSoon = _db.Movies.Where(m => m.Status == "coming").OrderByDescending(m => m.Id).ToList();
        NowShowing = allNowShowing.Where(m => m.Id != 1).ToList();
        ComingSoon = allComingSoon.Where(m => m.Id != 1).ToList();
        HeroMovie = _db.Movies.FirstOrDefault(m => m.Id == 1);
    }
} 