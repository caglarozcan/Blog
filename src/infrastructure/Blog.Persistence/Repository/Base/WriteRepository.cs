using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public abstract class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
	private readonly DbContext _dbContext;

	public WriteRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public DbSet<T> Table => _dbContext.Set<T>();

	public async Task<bool> DeleteAsync(T entity)
	{
		var result = Table.Remove(entity);
		return result.State == EntityState.Deleted;
	}

	public async Task<bool> DeleteAsync(Guid id)
	{
		var result = Table.Remove(Table.FirstOrDefault(q => q.Id == id));
		return result.State == EntityState.Deleted;
	}

	public async Task<bool> InsertAsync(T entity, CancellationToken cancellationToken = default)
	{
		var result = await Table.AddAsync(entity, cancellationToken);
		return result.State == EntityState.Added;
	}

	public async Task<bool> UpdateAsync(T entity)
	{
		var result = Table.Update(entity);
		return result.State == EntityState.Modified;
	}
}
