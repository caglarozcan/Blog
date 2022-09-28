using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class MediaReadRepository : ReadRepository<Media>, IMediaReadRepository
	{
		public MediaReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
