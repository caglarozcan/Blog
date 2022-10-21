using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class SettingGroupReadRepository : ReadRepository<SettingGroup>, ISettingGroupReadRepository
	{
		public SettingGroupReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
