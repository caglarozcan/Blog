using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Repository
{
	public interface IRepository<T> where T : class, new()
	{
		DbSet<T> Table { get; }
	}
}
