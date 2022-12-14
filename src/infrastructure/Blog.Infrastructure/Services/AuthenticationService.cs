using Blog.Application.Dto.UserDto;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using System.Security.Claims;

namespace Blog.Infrastructure.Services;

public class AuthenticationService : BaseService, IAuthenticationService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IHashService _hashService;

	public AuthenticationService(IUnitOfWork unitOfWork, IHashService hashService)
	{
		this._unitOfWork = unitOfWork;
		this._hashService = hashService;
	}

	public async Task<Response<ClaimsPrincipal>> LoginAsync(UserLoginDto data)
	{

		data.Password = _hashService.Hash(data.Password);

		var user = await _unitOfWork.UserReadRepository.GetAsync(u => u.Email.Equals(data.Email) && u.Password.Equals(data.Password));

		if (user == null)
		{
			return new Response<ClaimsPrincipal>(message: "Kullanıcı adı veya şifre hatalı.", success: false);
		}
		else
		{
			var role = await _unitOfWork.UserReadRepository.GetAuthenticatedUserRolesAsync(user.Id);

			var claims = new List<Claim> {
				new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Surname, user.LastName),
				new Claim(ClaimTypes.GivenName, String.Concat(user.Name, " ", user.LastName)),
				new Claim(ClaimTypes.Role, role.Name)
			};

			var identity = new ClaimsIdentity(claims, "UserLoginCookie");
			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

			user.LastLogin = DateTime.Now;
			await _unitOfWork.UserWriteRepository.UpdateAsync(user);
			await _unitOfWork.SaveAsync();

			return new Response<ClaimsPrincipal>(message: "Oturum açma işlemi başarılı.", success: true, value: claimsPrincipal);
		}
	}
}
