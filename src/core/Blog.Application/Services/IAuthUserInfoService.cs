namespace Blog.Application.Services;

public interface IAuthUserInfoService
{
	Guid Id { get; }

	string FirstName { get; }

	string LastName { get; }

	string FullName { get; }

	string Email { get; }
}
