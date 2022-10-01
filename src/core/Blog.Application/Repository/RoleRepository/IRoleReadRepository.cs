using Blog.Application.Dto.RoleDto;
using Blog.Domain.Entities;

namespace Blog.Application.Repository
{
	public interface IRoleReadRepository : IReadRepository<Role>
	{
		#region Read
		Task<List<RoleSelectDto>> GetSelectRolesAsync();
		#endregion
	}
}
