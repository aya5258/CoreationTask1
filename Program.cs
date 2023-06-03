
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductCustomer.Data;
using ProductCustomer.Data.Services;
using ProductCustomer.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PCContex>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
            });
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<PCContex>().AddDefaultTokenProviders();

            //Services configuration

            builder.Services.AddScoped<ICustomerService,Customerservice>();
            builder.Services.AddScoped<IproductService,ProductService>();
            builder.Services.AddTransient<AppDBinit>();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(
                options =>  
                {
                    options.LoginPath = "/Access/Login";
                    options.AccessDeniedPath = "/Access/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

       

            app.UseHttpsRedirection();

            SeedDatabase();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //AppDBinit.SeedUsersAndRolesAsync(app).Wait();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Access}/{action=Login}/{id?}");

          //  AppDBinitializer.SeedUsersAndRolesAsync(app).Wait();
            app.Run();

            void SeedDatabase() //can be placed at the very bottom under app.Run()
            {
                AppDBinit.Seed(app);
            }
        }
    }
}