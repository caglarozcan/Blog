using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SettingsReadRepository : ReadRepository<Settings>, ISettingsReadRepository
{
	public SettingsReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
