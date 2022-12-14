using Blog.Application.Dto.RoleDto;
using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface IUserReadRepository : IReadRepository<User>
{
	Task<UserRoleDto> GetAuthenticatedUserRolesAsync(Guid userId);

	Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request);
}
