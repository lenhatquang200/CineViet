using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CineViet.Models;

public class MoviesManageEditModel : PageModel
{
    private readonly AppDbContext _db;
    public Movie Movie { get; set; }
    public MoviesManageEditModel(AppDbContext db) { _db = db; }
    public IActionResult OnGet(int id)
    {
        Movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (Movie == null) return RedirectToPage("/MoviesManage");
        return Page();
    }
    public IActionResult OnPost(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return RedirectToPage("/MoviesManage");
        movie.Name = Request.Form["Name"];
        movie.Genre = Request.Form["Genre"];
        movie.Duration = int.Parse(Request.Form["Duration"]);
        movie.Year = int.Parse(Request.Form["Year"]);
        movie.Rating = double.Parse(Request.Form["Rating"]);
        movie.Image = Request.Form["Image"];
        _db.SaveChanges();
        return RedirectToPage("/MoviesManage");
    }
} 