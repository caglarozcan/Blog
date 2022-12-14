using Blog.Application.Dto.RoleDto;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface IRoleReadRepository : IReadRepository<Role>
{
	#region Read
	Task<RoleSelectDto> GetSelectRolesAsync(Guid? id);
	#endregion
}
