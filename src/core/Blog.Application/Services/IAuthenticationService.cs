using Blog.Application.Dto.UserDto;
using Blog.Application.Response;
using System.Security.Claims;

namespace Blog.Application.Services;

public interface IAuthenticationService
{
	Task<Response<ClaimsPrincipal>> LoginAsync(UserLoginDto data);
}
