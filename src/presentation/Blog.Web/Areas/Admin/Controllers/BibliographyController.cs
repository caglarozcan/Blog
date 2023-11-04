using Blog.Application.Dto.BibliographyDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class BibliographyController : BaseController
{
	private IBibliographyService _bibliographyService;

	public BibliographyController(IBibliographyService bibliographyService)
	{
		this._bibliographyService = bibliographyService;
	}

	#region Functions
	#region Create
	public async ValueTask<IActionResult> Insert(BibliographyInsertDto data)
	{
		return Ok(data);
	}
	#endregion

	#region Read
	public async ValueTask<IActionResult> Index()
	{
		return View();
	}

	[HttpGet]
	public async ValueTask<IActionResult> GetList(DataListRequest request)
	{
		return Ok(await _bibliographyService.GetBibliographyListAsync(request));
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
