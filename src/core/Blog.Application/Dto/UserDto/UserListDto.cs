namespace Blog.Application.Dto.UserDto;

public class UserListDto
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string LastName { get; set; }

	public string NickName { get; set; }

	public string Email { get; set; }

	public string RoleName { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? LastLogin { get; set; }

	public byte Status { get; set; }
}
