using Blog.Application.Dto.TagsDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface ITicketService
{
	#region Create
	ValueTask<Response<ProblemDetails>> InsertAsync(TagInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	ValueTask<PagingDataResponse<TagListDto>> ListAsync(DataListRequest request);

	ValueTask<Response<TagListDto>> GetUpdatedTicketAsync(Guid id);
	#endregion

	#region Update
	ValueTask<Response<ProblemDetails>> EditAsync(TagEditDto data, ModelStateDictionary modelState);
	#endregion

	#region Delete
	ValueTask<Response.Response> DeleteAsync(Guid id);
	#endregion
}
