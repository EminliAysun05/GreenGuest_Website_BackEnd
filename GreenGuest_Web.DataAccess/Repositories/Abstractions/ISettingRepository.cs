using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.DataAccess.Repositories.Abstractions
{
	public interface ISettingRepository : IRepository<Setting>
	{
		Task<Setting?> GetSingleAsync(Expression<Func<Setting, bool>> predicate);
	}
}
