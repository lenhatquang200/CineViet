using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CineViet.Models;

public class LoginModel : PageModel
{
    private readonly AppDbContext _db;
    public LoginModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [BindProperty]
    [Required]
    public string Password { get; set; }
    public string ErrorMessage { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Vui lòng nhập đầy đủ thông tin.";
            return Page();
        }
        var user = _db.Users.FirstOrDefault(u => u.Email == Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
        {
            ErrorMessage = "Email hoặc mật khẩu không đúng.";
            return Page();
        }
        HttpContext.Session.SetString("UserName", user.FullName);
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");
        if (user.IsAdmin)
            return Redirect("/Dashboard");
        return Redirect("/Index?login=1");
    }
} 