using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
	public UserWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
