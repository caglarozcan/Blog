using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents;

public class CategoryTreeComponent : ViewComponent
{
	private readonly ICategoryService _categoryService;

	public CategoryTreeComponent(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var items = await _categoryService.GetHierarchicalCategoryListsync();
		return View(items);
	}
}