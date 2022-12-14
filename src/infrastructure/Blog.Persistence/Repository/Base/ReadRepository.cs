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

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
		{
			return await Table.AsNoTracking().AnyAsync(expression, cancellationToken);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
		{
			return expression == null ? await Table.AsNoTracking().CountAsync(cancellationToken) : await Table.AsNoTracking().CountAsync(expression, cancellationToken);
		}

		public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table.AsNoTracking();

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

			return await query.ToListAsync(cancellationToken);
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table.AsNoTracking();

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

			return await query.FirstOrDefaultAsync(cancellationToken);
		}

		public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = Table.AsNoTracking();

			if (includes.Any())
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}

			return await query.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
		}
	}
}
