using GreenGuest_Web.Core.Entities.Core;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.DataAccess.Repositories.Abstractions.Generic
{
	public interface IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		Task<T?> GetByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
		Task<T> CreateAsync(T entity);
		T Update(T entity);
		T Delete(T entity);
		Task<int> SaveChangesAsync();
		IQueryable<T> Paginate(IQueryable<T> query, int limit, int page = 1);
	}
}
