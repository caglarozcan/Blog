using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
	{
		public RoleWriteRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
