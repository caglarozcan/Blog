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

	#region Functions
	#region Create

	#endregion

	#region Read
	public async Task<IActionResult> Index()
	{
		return View();
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion

}
