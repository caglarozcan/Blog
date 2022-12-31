namespace Blog.Application.Dto.UserDto;

public sealed class UserAuthInfoDto
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public string Roles { get; set; }
}
