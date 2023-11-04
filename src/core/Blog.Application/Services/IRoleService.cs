using Blog.Application.Dto.RoleDto;

namespace Blog.Application.Services;

public interface IRoleService
    {
	#region Read
	ValueTask<RoleSelectDto> GetSelectRolesAsync(Guid? id);
	#endregion
}
