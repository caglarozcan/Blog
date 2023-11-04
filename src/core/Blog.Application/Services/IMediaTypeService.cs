using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface IMediaTypeService
{
	#region Create
	ValueTask<Response<ProblemDetails>> InsertAsync(MediaTypeInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	ValueTask<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request);

	ValueTask<Response<MediaTypeUpdateDto>> GetUpdatedMediaTypeAsync(Guid id);

	ValueTask<MediaTypeSelectDto> GetMediaTypeSelectAsync(Guid? id);
	#endregion

	#region Update
	ValueTask<Response.Response> StatusChangeAsync(Guid id);

	ValueTask<Response<ProblemDetails>> UpdateAsync(MediaTypeUpdateDto data, ModelStateDictionary modelState);
	#endregion

	#region Delete
	ValueTask<Response.Response> DeleteAsync(Guid id);
	#endregion
}
