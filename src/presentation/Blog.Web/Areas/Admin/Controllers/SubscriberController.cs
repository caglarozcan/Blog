using Blog.Application.Request;
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

	public async Task<IActionResult> GetList(DataListRequest request)
	{
		var list = await _subscriberService.GetSubscriberListAsync(request);

		return Ok(list);
	}
	#endregion

	#region Update
	[HttpPost]
	public async Task<IActionResult> StatusChange(Guid id)
	{
		var result = await _subscriberService.StatusChangeAsync(id);

		return Ok(result);
	}
	#endregion

	#region Delete
	[HttpPost]
	public async Task<IActionResult> Delete(Guid id)
	{
		var result = await _subscriberService.DeleteAsync(id);

		return Ok(result);
	}
	#endregion
	#endregion

}
