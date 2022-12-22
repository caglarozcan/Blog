using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SubscriberWriteRepository : WriteRepository<Subscriber>, ISubscriberWriteRepository
{
	public SubscriberWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
