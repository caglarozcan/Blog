using Blog.Application.Dto.CategoryDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class CategoryController : BaseController
{
	private readonly ICategoryService _categoryService;

	public CategoryController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	#region Functions
	#region Create
	[HttpPost]
	public async ValueTask<IActionResult> Insert(CategoryInsertDto data)
	{				
		var result = await _categoryService.InsertAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result) {
			StatusCode = 400
		};
	}
	#endregion

	#region Read
	public async ValueTask<IActionResult> Index()
	{
		return View();
	}

	public async ValueTask<IActionResult> GetList(DataListRequest request)
	{
		var list = await _categoryService.GetCategoryListAsync(request);

		return Ok(list);
	}

	public async ValueTask<IActionResult> EditInfo(Guid id)
	{
		var result = await _categoryService.GetUpdatedCategoryInfoAsync(id);

		return Ok(result);
	}
	#endregion

	#region Update
	[HttpPost]
	public async ValueTask<IActionResult> Edit(CategoryEditDto data)
	{
		var result = await _categoryService.EditAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	public async ValueTask<IActionResult> StatusChange(Guid id)
	{
		var result = await _categoryService.StatusChangeAsync(id);

		return Ok(result);
	}
	#endregion

	#region Delete
	public async ValueTask<IActionResult> Delete(Guid id)
	{
		var result = await _categoryService.DeleteAsync(id);

		return Ok(result);
	}
	#endregion
	#endregion
}
