using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GreenGuest_Web.DataAccess.Contexts
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		private readonly BaseEntityInterceptor _baseEntityInterceptor;
		public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor baseEntityInterceptor) : base(options)
		{
			_baseEntityInterceptor = baseEntityInterceptor;
		}
		
		public required DbSet<CategoryItem> CategoryItems { get; set; }
		public required DbSet<FaqItem> FaqItems { get; set; }
		public required DbSet<Setting> Settings { get; set; }
		public required DbSet<Slider> Sliders { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			_addQueryFilters(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.AddInterceptors(_baseEntityInterceptor);

			base.OnConfiguring(optionsBuilder);
		}

		private static void _addQueryFilters(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Slider>().HasQueryFilter(x => EF.Property<bool>(x, "IsDeleted") == false);
			modelBuilder.Entity<CategoryItem>().HasQueryFilter(x => EF.Property<bool>(x, "IsDeleted") == false);
			modelBuilder.Entity<FaqItem>().HasQueryFilter(x => EF.Property<bool>(x, "IsDeleted") == false);

		}


	}
}
