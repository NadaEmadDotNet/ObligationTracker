using ExpensesTracker.Models;
using ExpensesTracker.Models.Rpositories;
using ExpensesTracker.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IObligation, ObligationRepo>();
            builder.Services.AddScoped<IObligationService, ObligationsService>();
            builder.Services.AddScoped<IObligation, ObligationRepo>();
            // Database connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(30); // يخلي الكوكيز تعيش 30 يوم
                options.SlidingExpiration = true; // يتجدد مع كل دخول
            });

            // Identity setup
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;        // مش لازم capital
                options.Password.RequireNonAlphanumeric = false;  // مش لازم رموز
                options.Password.RequiredLength = 6;              // أقل طول
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Authentication + Authorization
            app.UseAuthentication();  // ✅ لازم قبل UseAuthorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

