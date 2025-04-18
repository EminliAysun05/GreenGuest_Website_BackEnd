using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace GreenGuest_Web.Business.ServiceRegistrations;

public static class BusinessLayerServiceRegistration
{
	public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(BusinessLayerServiceRegistration).Assembly);
		services.AddAutoMapper(typeof(BusinessLayerServiceRegistration).Assembly);
		services.AddScoped<ICategoryItemService, CategoryItemService>();
		services.AddScoped<ICloudinaryService, CloudinaryService>();
		services.AddScoped<IFaqItemService, FaqItemService>();
		services.AddScoped<ISettingService, SettingService>();
		services.AddScoped<ISliderService, SliderService>();

		return services;
	}
}
