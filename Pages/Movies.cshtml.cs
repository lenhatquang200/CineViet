using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using CineViet.Models;

public class MoviesModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Movie> Movies { get; set; }
    public MoviesModel(AppDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        var status = Request.Query["status"].ToString();
        var search = Request.Query["search"].ToString();
        var query = _db.Movies.AsQueryable();
        if (!string.IsNullOrEmpty(status) && status != "all")
        {
            query = query.Where(m => m.Status == status);
        }
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(m => m.Name.Contains(search));
        }
        Movies = query.ToList();
    }
} 