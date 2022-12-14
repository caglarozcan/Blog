using Blog.Application.Dto.CategoryDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents;

public class CategoryList : ViewComponent
{
	private readonly ICategoryService _categoryService;

	public CategoryList(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	public async Task<IViewComponentResult> InvokeAsync(Guid? id)
	{
		var items = await GetItemsAsync(id);
		return View(items);
	}

	private Task<CategorySelectDto> GetItemsAsync(Guid? id)
	{
		return _categoryService.GetSelectCategories(id);
	}
}
