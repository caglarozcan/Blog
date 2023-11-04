using Blog.Application.Dto.UserDto;
using Blog.Application.Response;
using System.Security.Claims;

namespace Blog.Application.Services;

public interface IAuthenticationService
{
	ValueTask<Response<ClaimsPrincipal>> LoginAsync(UserLoginDto data);
}
