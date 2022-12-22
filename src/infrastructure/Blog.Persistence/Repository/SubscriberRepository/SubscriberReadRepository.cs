using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SubscriberReadRepository : ReadRepository<Subscriber>, ISubscriberReadRepository
{
	public SubscriberReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
