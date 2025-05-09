using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using CineViet.Models;

public class MoviesManageModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Movie> Movies { get; set; }
    public MoviesManageModel(AppDbContext db) { _db = db; }
    public void OnGet()
    {
        Movies = _db.Movies.ToList();
    }
    public IActionResult OnPostDelete(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
        return RedirectToPage();
    }
} 