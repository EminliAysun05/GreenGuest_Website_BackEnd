using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.DataInitializers;
using GreenGuest_Web.DataAccess.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GreenGuest_Web.DataAccess.ServiceRegistrations;

public static class DataAccesServiceRegistration
{
	public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

		services.AddScoped<BaseEntityInterceptor>();
		services.AddScoped<DbContextInitializer>();

		services.AddMemoryCache();

	//	_addRepositories(services);
		_addIdentity(services);
	

		return services;
	}

	//private static void _addRepositories(IServiceCollection services)
	//{
	//	services.AddScoped<IAboutRepository, AboutRepository>();
	//	services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
	//	services.AddScoped<IAttedanceRepository, AttedanceRepository>();
	//	services.AddScoped<IBrandRepository, BrandRepository>();
	//	services.AddScoped<IBranchRepository, BranchRepository>();
	//	services.AddScoped<IBasketItemRepository, BasketItemRepository>();
	//	services.AddScoped<ICategoryRepository, CategoryRepository>();
	//	services.AddScoped<ICommentRepository, CommentRepository>();
	//	services.AddScoped<IDensityRepository, DensityRepository>();
	//	services.AddScoped<ILanguageRepository, LanguageRepository>();
	//	services.AddScoped<ISliderRepository, SliderRepository>();
	//	services.AddScoped<ISettingRepository, SettingRepository>();
	//	services.AddScoped<IProductRepository, ProductRepository>();
	//	services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
	//	services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
	//	services.AddScoped<ISubscriberRepository, SubscriberRepository>();
	//	services.AddScoped<IStatusRepository, StatusRepository>();
	//	services.AddScoped<IOrderRepository, OrderRepository>();
	//	services.AddScoped<IPaymentRepository, PaymentRepository>();
	//	services.AddScoped<IOrderItemRepository, OrderItemRepository>();
	//	services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();
	//}



	private static void _addIdentity(IServiceCollection services)
	{
		services.AddIdentity<AppUser, IdentityRole>(options =>
		{
			options.Password.RequiredLength = 6;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireUppercase = false;
			options.User.RequireUniqueEmail = true;
			options.SignIn.RequireConfirmedEmail = true;
			options.Lockout.AllowedForNewUsers = false;
			options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
			options.Lockout.MaxFailedAccessAttempts = 3;

		}).AddEntityFrameworkStores<AppDbContext>()
		  .AddDefaultTokenProviders();
	}
}
