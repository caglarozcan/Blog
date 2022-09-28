using Blog.Application.Dto.RoleDto;
using Blog.Domain.Entities;

namespace Blog.Application.Repository
{
	public interface IUserReadRepository : IReadRepository<User>
	{
		Task<UserRoleDto> GetAuthenticatedUserRolesAsync(Guid userId); 
	}
}
