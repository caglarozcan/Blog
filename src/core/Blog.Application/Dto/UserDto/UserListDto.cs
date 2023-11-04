namespace Blog.Application.Dto.UserDto;

public sealed class UserListDto
{
	public Guid Id { get; set; }

	public required string Name { get; set; }

	public required string LastName { get; set; }

	public required string NickName { get; set; }

	public required string Email { get; set; }

	public required string RoleName { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? LastLogin { get; set; }

	public byte Status { get; set; }
}
