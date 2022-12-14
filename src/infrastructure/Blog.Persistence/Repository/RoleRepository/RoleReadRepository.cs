using Blog.Application.Dto;
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
		public async Task<RoleSelectDto> GetSelectRolesAsync(Guid? id)
		{
			var options = await Table.AsNoTracking().Select(s => new SelectOptionsDto() { 
				Value = s.Id.ToString(),
				Text = s.Name
			}).ToListAsync();

			return new RoleSelectDto()
			{
				RoleId = id,
				Options = options
			};
		}
		#endregion
	}
}
