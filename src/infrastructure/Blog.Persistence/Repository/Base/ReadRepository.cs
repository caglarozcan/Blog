using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Persistence.Repository
{
	public abstract class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
	{
		private readonly DbContext _dbContext;

		public ReadRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public DbSet<T> Table => _dbContext.Set<T>();

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await Table.AnyAsync(expression);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
		{
			return expression == null ? await Table.CountAsync() : await Table.CountAsync(expression);
		}

		public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table;

			if (expression != null)
			{
				query = query.Where(expression);
			}

			if (includes.Any())
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}

			return await query.ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table;

			if (expression != null)
			{
				query = query.Where(expression);
			}

			if (includes.Any())
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}

			return await query.FirstOrDefaultAsync();
		}

		public async Task<T> GetAsync(Guid id, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table;

			if (includes.Any())
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}

			return await query.FirstOrDefaultAsync(q => q.Id == id);
		}
	}
}
