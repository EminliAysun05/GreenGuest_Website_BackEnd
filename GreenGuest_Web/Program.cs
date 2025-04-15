using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.Interceptors;
using GreenGuest_Web.DataAccess.ServiceRegistrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

			// 🔹 Identity konfiqurasiyası
			builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();
			// Add services to the container.
			builder.Services.AddScoped<BaseEntityInterceptor>();
			builder.Services.AddControllersWithViews();
			builder.Services.AddDataAccessServices(builder.Configuration);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			builder.Services.AddAuthorization();
			builder.Services.AddAuthentication();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
