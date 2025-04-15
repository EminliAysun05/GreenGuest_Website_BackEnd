using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using GreenGuest_Web.DataAccess.Repositories.Implementations.Generic;

namespace GreenGuest_Web.DataAccess.Repositories.Implementations;

internal class FaqItemRepository : Repository<FaqItem>, IFaqItemRepository
{
	public FaqItemRepository(AppDbContext context) : base(context)
	{
	}
}
