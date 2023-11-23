using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using OLX_Ala.Data;
using FluentValidation;
using DataAccess.Data.Entities;
using OLX_Ala.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using OLX_Ala.Helpers;

namespace OLX_Ala
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connStr = builder.Configuration.GetConnectionString("LocalDb");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AlaOlxDbContext>(opts=>opts.UseSqlServer(connStr));

            //builder.Services.AddIdentity<User,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AlaOlxDbContext>();
            builder.Services.AddIdentity<User, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddEntityFrameworkStores<AlaOlxDbContext>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout=TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential= true;
            });


            var app = builder.Build();

            using(var scope=app.Services.CreateScope())
            {
                var serviceProvider=scope.ServiceProvider;
                SeedExtensions.SeedRoles(serviceProvider).Wait();
                SeedExtensions.SeedAdmin(serviceProvider).Wait();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}