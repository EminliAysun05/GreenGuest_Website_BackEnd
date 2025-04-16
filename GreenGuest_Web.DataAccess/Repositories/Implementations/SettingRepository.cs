using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using GreenGuest_Web.DataAccess.Repositories.Implementations.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GreenGuest_Web.DataAccess.Repositories.Implementations;

internal class SettingRepository : Repository<Setting>, ISettingRepository
{
	private readonly AppDbContext _context;
	public SettingRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<Setting?> GetSingleAsync(Expression<Func<Setting, bool>> predicate)
	{
		return await _context.Settings.FirstOrDefaultAsync(predicate);
	}
}
