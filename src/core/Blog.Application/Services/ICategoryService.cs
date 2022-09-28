using Blog.Application.Dto.CategoryDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services
{
	public interface ICategoryService
	{
		#region Create
		Task<Response<ProblemDetails>> InsertAsync(CategoryInsertDto data, ModelStateDictionary modelState);
		#endregion

		#region Read
		Task<PagingDataResponse<CategoryListDto>> GetCategoryListAsync(DataListRequest request);

		Task<Response<CategoryListDto>> GetUpdatedCategoryInfoAsync(Guid id);
		#endregion

		#region Update
		Task<Response<ProblemDetails>> EditAsync(CategoryEditDto data, ModelStateDictionary modelState);

		Task<Response.Response> StatusChangeAsync(Guid id);
		#endregion

		#region Delete
		Task<Response.Response> DeleteAsync(Guid id);
		#endregion
	}
}
