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
	public IActionResult Index()
	{
		return View();
	}

	public async ValueTask<IActionResult> GetList(DataListRequest request)
	{
		var list = await _subscriberService.GetSubscriberListAsync(request);

		return Ok(list);
	}
	#endregion

	#region Update
	[HttpPost]
	public async ValueTask<IActionResult> StatusChange(Guid id)
	{
		var result = await _subscriberService.StatusChangeAsync(id);

		return Ok(result);
	}
	#endregion

	#region Delete
	[HttpPost]
	public async ValueTask<IActionResult> Delete(Guid id)
	{
		var result = await _subscriberService.DeleteAsync(id);

		return Ok(result);
	}
	#endregion
	#endregion

}
