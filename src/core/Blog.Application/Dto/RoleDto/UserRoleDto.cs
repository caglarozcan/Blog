namespace Blog.Application.Dto.RoleDto;

public sealed class UserRoleDto
{
	public Guid Id { get; set; }

	public required string Name { get; set; }
}
