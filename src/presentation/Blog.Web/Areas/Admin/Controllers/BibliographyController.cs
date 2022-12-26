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
