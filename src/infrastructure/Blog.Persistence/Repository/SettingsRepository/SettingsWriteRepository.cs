using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SettingsWriteRepository : WriteRepository<Settings>, ISettingsWriteRepository
{
	public SettingsWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
