using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using CineViet.Models;

public class AccountModel : PageModel
{
    private readonly AppDbContext _db;
    public User UserInfo { get; set; }
    public string SuccessMessage { get; set; }
    public string ErrorMessage { get; set; }
    public AccountModel(AppDbContext db) { _db = db; }
    public void OnGet()
    {
        LoadUser();
    }
    public void OnPost()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) { ErrorMessage = "Bạn chưa đăng nhập."; return; }
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) { ErrorMessage = "Không tìm thấy tài khoản."; return; }
        var fullName = Request.Form["FullName"].ToString();
        var email = Request.Form["Email"].ToString();
        var phone = Request.Form["Phone"].ToString();
        var currentPassword = Request.Form["CurrentPassword"].ToString();
        var newPassword = Request.Form["NewPassword"].ToString();
        var confirmPassword = Request.Form["ConfirmPassword"].ToString();
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
        {
            ErrorMessage = "Vui lòng nhập đầy đủ thông tin.";
            LoadUser();
            return;
        }
        // Kiểm tra email đã tồn tại cho user khác
        if (_db.Users.Any(u => u.Email == email && u.Id != user.Id))
        {
            ErrorMessage = "Email đã được sử dụng.";
            LoadUser();
            return;
        }
        user.FullName = fullName;
        user.Email = email;
        user.Phone = phone;
        // Đổi mật khẩu nếu có nhập
        if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
        {
            if (string.IsNullOrEmpty(currentPassword) || !BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash))
            {
                ErrorMessage = "Mật khẩu hiện tại không đúng.";
                LoadUser();
                return;
            }
            if (newPassword != confirmPassword)
            {
                ErrorMessage = "Mật khẩu mới không khớp.";
                LoadUser();
                return;
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        }
        _db.SaveChanges();
        SuccessMessage = "Cập nhật thành công.";
        // Cập nhật lại session nếu đổi tên
        HttpContext.Session.SetString("UserName", user.FullName);
        LoadUser();
    }
    private void LoadUser()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            UserInfo = _db.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
} 