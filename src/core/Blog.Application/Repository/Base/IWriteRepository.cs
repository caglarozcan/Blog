namespace Blog.Application.Repository;

public interface IWriteRepository<T> : IRepository<T> where T : class, new()
{
	Task<bool> InsertAsync(T entity, CancellationToken cancellationToken = default);

	Task<bool> UpdateAsync(T entity);

	Task<bool> DeleteAsync(T entity);

	Task<bool> DeleteAsync(Guid id);
}
