using Blog.Application.Dto.MediaDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services;

public interface IMediaService
{
	#region Create
	Task<Response.Response> FileUploadAsync(IFormFile file);
	#endregion

	#region Read
	Task<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request);
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
}
