using Blog.Application.Dto.MediaDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services;

public interface IMediaService
{
	#region Create
	ValueTask<Response.Response> FileUploadAsync(IFormFile file);
	#endregion

	#region Read
	ValueTask<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request);

	ValueTask<PagingDataResponse<MediaListDto>> GetFilteredMediaListAsync(DataListRequest request);

	ValueTask<MediaInfoDto> GetMediaInfoAsync(Guid id);
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
}
