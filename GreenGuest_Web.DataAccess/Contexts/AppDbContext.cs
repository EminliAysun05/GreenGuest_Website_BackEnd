using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web.DataAccess.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		private readonly BaseEntityInterceptor _baseEntityInterceptor;
		public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor baseEntityInterceptor) : base(options)
		{
			_baseEntityInterceptor = baseEntityInterceptor;
		}

	}
}
