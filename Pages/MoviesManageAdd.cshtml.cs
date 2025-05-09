using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using CineViet.Models;

public class MoviesManageAddModel : PageModel
{
    private readonly AppDbContext _db;
    public MoviesManageAddModel(AppDbContext db) { _db = db; }
    public void OnGet() { }
    public IActionResult OnPost()
    {
        var name = Request.Form["Name"].ToString();
        var genre = Request.Form["Genre"].ToString();
        var duration = int.Parse(Request.Form["Duration"]);
        var year = int.Parse(Request.Form["Year"]);
        var rating = double.Parse(Request.Form["Rating"]);
        var image = Request.Form["Image"].ToString();
        var movie = new Movie
        {
            Name = name,
            Genre = genre,
            Duration = duration,
            Year = year,
            Rating = rating,
            Image = image
        };
        _db.Movies.Add(movie);
        _db.SaveChanges();
        return RedirectToPage("/MoviesManage");
    }
} 