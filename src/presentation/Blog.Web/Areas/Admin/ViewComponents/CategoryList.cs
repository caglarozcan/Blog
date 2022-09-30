using Blog.Application.Dto.CategoryDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents
{
	public class CategoryList : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryList(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await GetItemsAsync();
			return View(items);
		}

		private Task<List<CategorySelectDto>> GetItemsAsync()
		{
			return _categoryService.GetSelectCategories();
		}
	}
}
