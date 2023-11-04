using Blog.Application.Dto.SubscriberDto;
using Blog.Application.Request;
using Blog.Application.Response;

namespace Blog.Application.Services;

public interface ISubscriberService
{
	#region Functions
	#region Create

	#endregion

	#region Read
	ValueTask<PagingDataResponse<SubscriberListDto>> GetSubscriberListAsync(DataListRequest request);
	#endregion

	#region Update
	ValueTask<Response.Response> StatusChangeAsync(Guid id);
	#endregion

	#region Delete
	ValueTask<Response.Response> DeleteAsync(Guid id);
	#endregion
	#endregion
}
