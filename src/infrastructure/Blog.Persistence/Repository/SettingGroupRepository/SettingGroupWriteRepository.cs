using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SettingGroupWriteRepository : WriteRepository<SettingGroup>, ISettingGroupWriteRespository
{
	public SettingGroupWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
