using Blog.Application.Dto.RoleDto;
using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
	{
		public RoleReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}

		#region Read
		public async Task<List<RoleSelectDto>> GetSelectRolesAsync()
		{
			return await Table.Select(s => new RoleSelectDto() { 
				Id = s.Id,
				Name = s.Name
			}).ToListAsync();
		}
		#endregion
	}
}
