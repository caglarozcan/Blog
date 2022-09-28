using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class MediaWriteRepository : WriteRepository<Media>, IMediaWriteRepository
	{
		public MediaWriteRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
