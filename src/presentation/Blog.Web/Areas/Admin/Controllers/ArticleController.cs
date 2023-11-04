using Blog.Application.Dto.ArticleDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class ArticleController : BaseController
{
	private readonly IArticleService _articleService;

	public ArticleController(IArticleService articleService)
	{
		_articleService = articleService;
	}

	#region Functions
	#region Create
	[HttpPost]
	public async ValueTask<IActionResult> Insert(ArticleInsertDto data)
	{
		var result = await _articleService.InsertAsync(data, ModelState);

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

	public IActionResult Insert()
	{
		return View();
	}

	public IActionResult Series()
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
