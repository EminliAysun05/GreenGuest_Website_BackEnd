using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using GreenGuest_Web.DataAccess.Repositories.Implementations.Generic;

namespace GreenGuest_Web.DataAccess.Repositories.Implementations;

internal class CategoryItemRepository : Repository<CategoryItem>, ICategoryItemRepository
{
	public CategoryItemRepository(AppDbContext context) : base(context)
	{
	}
}
