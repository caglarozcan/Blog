using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services
{
	public interface IMediaTypeService
	{
		#region Create
		Task<Response<ProblemDetails>> InsertAsync(MediaTypeInsertDto data, ModelStateDictionary modelState);
		#endregion

		#region Read
		Task<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request);

		Task<Response<MediaTypeUpdateDto>> GetUpdatedMediaTypeAsync(Guid id);
		#endregion

		#region Update
		Task<Response.Response> StatusChangeAsync(Guid id);

		Task<Response<ProblemDetails>> UpdateAsync(MediaTypeUpdateDto data, ModelStateDictionary modelState);
		#endregion

		#region Delete
		Task<Response.Response> DeleteAsync(Guid id);
		#endregion
	}
}
