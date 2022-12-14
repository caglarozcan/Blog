using Blog.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Infrastructure.Services;

public class AuthUserInfoService : IAuthUserInfoService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public Guid Id { get; }

	public string FirstName { get; }
	
	public string LastName { get; }
	
	public string FullName { get; }
	
	public string Email { get; }

	public AuthUserInfoService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;

		var user = _httpContextAccessor.HttpContext.User;

		Id = Guid.Parse(user.FindFirst(ClaimTypes.SerialNumber).Value);
		FirstName = user.FindFirst(ClaimTypes.Name).Value;
		LastName = user.FindFirst(ClaimTypes.Surname).Value;
		FullName = user.FindFirst(ClaimTypes.GivenName).Value;
		Email = user.FindFirst(ClaimTypes.Email).Value;
	}
}
