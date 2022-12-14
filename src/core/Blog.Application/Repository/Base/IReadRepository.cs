using System.Linq.Expressions;

namespace Blog.Application.Repository
{
	public interface IReadRepository<T> : IRepository<T> where T : class, new()
	{
		Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

		Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

		Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

		Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

		Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
	}
}
