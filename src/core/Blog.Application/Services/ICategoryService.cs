using Blog.Application.Dto.CategoryDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface ICategoryService
{
	#region Create
	ValueTask<Response<ProblemDetails>> InsertAsync(CategoryInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	ValueTask<PagingDataResponse<CategoryListDto>> GetCategoryListAsync(DataListRequest request);

	ValueTask<Response<CategoryListDto>> GetUpdatedCategoryInfoAsync(Guid id);

	ValueTask<CategorySelectDto> GetSelectCategoriesAsync(Guid? id);

	ValueTask<List<HierarchicalCategoryListDto>> GetHierarchicalCategoryListsync();
	#endregion

	#region Update
	ValueTask<Response<ProblemDetails>> EditAsync(CategoryEditDto data, ModelStateDictionary modelState);

	ValueTask<Response.Response> StatusChangeAsync(Guid id);
	#endregion

	#region Delete
	ValueTask<Response.Response> DeleteAsync(Guid id);
	#endregion
}
