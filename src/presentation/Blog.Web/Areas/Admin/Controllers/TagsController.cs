using Blog.Application.Dto.TagsDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class TagsController : Controller
{
	private readonly ITicketService _ticketService;

	public TagsController(ITicketService ticketService)
	{
		_ticketService = ticketService;
	}

	#region Functions
	#region Create
	[HttpPost]
	public async Task<IActionResult> Insert(TagInsertDto data)
	{
		var result = await _ticketService.InsertAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}
	#endregion

	#region Read
	public IActionResult Index()
	{
		return View();
	}

	public async Task<IActionResult> GetList(DataListRequest request)
	{
		var list = await _ticketService.ListAsync(request);

		return Ok(list);
	}

	[HttpPost]
	public async Task<IActionResult> GetEditInfo(Guid id)
	{
		var result = await _ticketService.GetUpdatedTicketAsync(id);

		return Ok(result);
	}
	#endregion

	#region Update
	[HttpPost]
	public async Task<IActionResult> Edit(TagEditDto data)
	{
		var result = await _ticketService.EditAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}
	#endregion

	#region Delete
	[HttpPost]
	public async Task<IActionResult> Delete(Guid id)
	{
		var result = await _ticketService.DeleteAsync(id);

		return Ok(result);
	}
	#endregion
	#endregion
}
