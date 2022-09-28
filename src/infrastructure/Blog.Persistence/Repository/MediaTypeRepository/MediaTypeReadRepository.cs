using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	internal class MediaTypeReadRepository : ReadRepository<MediaType>, IMediaTypeReadRepository
	{
		public MediaTypeReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
