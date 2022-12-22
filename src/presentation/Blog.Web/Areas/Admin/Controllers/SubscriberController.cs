using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class SubscriberController : BaseController
{
	private readonly ISubscriberService _subscriberService;

	public SubscriberController(ISubscriberService subscriberService)
	{
		_subscriberService = subscriberService;
	}

	public async Task<IActionResult> Index()
	{
		return View();
	}
}
