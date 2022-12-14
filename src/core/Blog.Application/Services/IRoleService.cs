using Blog.Application.Dto.RoleDto;

namespace Blog.Application.Services;

public interface IRoleService
    {
	#region Read
	Task<RoleSelectDto> GetSelectRolesAsync(Guid? id);
	#endregion
}
