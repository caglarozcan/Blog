using Blog.Application.Dto.RoleDto;
using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class UserReadRepository : ReadRepository<User>, IUserReadRepository
	{
		private DbSet<UserRoles> _userRoleTable { get; }

		public UserReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
			this._userRoleTable = dbContext.Set<UserRoles>();
		}

		public async Task<UserRoleDto> GetAuthenticatedUserRolesAsync(Guid userId)
		{
			var role = await _userRoleTable.Where(r => r.UserId == userId).Include(i => i.Role).FirstOrDefaultAsync();

			return new UserRoleDto()
			{
				Id = role.RoleId,
				Name = role.Role.Name
			};
		}
	}
}
