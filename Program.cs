namespace CineViet
{
    using Microsoft.EntityFrameworkCore;
    using CineViet.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSession();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.MapRazorPages();
            app.Run();
        }
    }
}
