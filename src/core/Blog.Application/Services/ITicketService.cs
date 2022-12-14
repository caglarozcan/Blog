using Blog.Application.Dto.TagsDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface ITicketService
{
	#region Create
	Task<Response<ProblemDetails>> InsertAsync(TagInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	Task<PagingDataResponse<TagListDto>> ListAsync(DataListRequest request);

	Task<Response<TagListDto>> GetUpdatedTicketAsync(Guid id);
	#endregion

	#region Update
	Task<Response<ProblemDetails>> EditAsync(TagEditDto data, ModelStateDictionary modelState);
	#endregion

	#region Delete
	Task<Response.Response> DeleteAsync(Guid id);
	#endregion
}
