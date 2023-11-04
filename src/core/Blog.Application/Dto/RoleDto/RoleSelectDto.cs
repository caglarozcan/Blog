namespace Blog.Application.Dto.RoleDto;

public sealed class RoleSelectDto
{
	public Guid? RoleId { get; set; }

	public List<SelectOptionsDto>? Options { get; set; }
}
