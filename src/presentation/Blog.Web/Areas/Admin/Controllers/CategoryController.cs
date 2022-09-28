using Blog.Application.Dto.CategoryDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator, Editör")]
	public class CategoryController : BaseController
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region Create
		[HttpPost]
		public async Task<IActionResult> Insert(CategoryInsertDto data)
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
		public async Task<IActionResult> GetList(DataListRequest request)
		{
			var list = await _categoryService.GetCategoryListAsync(request);

			return Ok(list);
		}

		public async Task<IActionResult> EditInfo(Guid id)
		{
			var result = await _categoryService.GetUpdatedCategoryInfoAsync(id);

			return Ok(result);
		}
		#endregion

		#region Update
		[HttpPost]
		public async Task<IActionResult> Edit(CategoryEditDto data)
		{
			var result = await _categoryService.EditAsync(data, ModelState);

			if (true.Equals(result.Success))
				return Ok(result);

			return new ObjectResult(result.Value != null ? result.Value : result)
			{
				StatusCode = 400
			};
		}

		public async Task<IActionResult> StatusChange(Guid id)
		{
			var result = await _categoryService.StatusChangeAsync(id);

			return Ok(result);
		}
		#endregion

		#region Delete
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _categoryService.DeleteAsync(id);

			return Ok(result);
		}
		#endregion


		
	}
}
