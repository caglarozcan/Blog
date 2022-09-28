using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class MediaTypeWriteRepository : WriteRepository<MediaType>, IMediaTypeWriteRepository
	{
		public MediaTypeWriteRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
