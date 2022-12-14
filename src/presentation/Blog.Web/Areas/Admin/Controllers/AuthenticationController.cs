using Blog.Application.Dto.UserDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class AuthenticationController : Controller
{
	private readonly Blog.Application.Services.IAuthenticationService _authenticationService;

	public AuthenticationController(Blog.Application.Services.IAuthenticationService authenticationService)
	{
		this._authenticationService = authenticationService;
	}

	public async Task<IActionResult> Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Index(UserLoginDto data)
	{
		if(!ModelState.IsValid)
			return View(data);

		var result = await _authenticationService.LoginAsync(data);

		if (true.Equals(result.Success))
		{
			await HttpContext.SignInAsync(result.Value);
			return RedirectToRoute("AdminHome");
		}
		else
		{
			return View(data);
		}
	}

	public async Task<IActionResult> LogOut()
	{
		await HttpContext.SignOutAsync();
		return RedirectToAction("Index");
	}
}
