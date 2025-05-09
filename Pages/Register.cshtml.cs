using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using CineViet.Models;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _db;
    public RegisterModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    [Required]
    public string FullName { get; set; }
    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [BindProperty]
    [Required]
    public string Phone { get; set; }
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
        if (_db.Users.Any(u => u.Email == Email))
        {
            ErrorMessage = "Email đã được sử dụng.";
            return Page();
        }
        var user = new User
        {
            FullName = FullName,
            Email = Email,
            Phone = Phone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password),
            CreatedAt = DateTime.Now
        };
        _db.Users.Add(user);
        _db.SaveChanges();
        return RedirectToPage("/Login", new { registered = 1 });
    }
} 