namespace Blog.Application.Dto.UserDto;

public sealed class UserAuthInfoDto
{
	public Guid Id { get; set; }

	public required string Name { get; set; }

	public required string LastName { get; set; }

	public required string Email { get; set; }

	public required string Roles { get; set; }
}
