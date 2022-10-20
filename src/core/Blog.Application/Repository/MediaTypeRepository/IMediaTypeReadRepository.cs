using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository
{
	public interface IMediaTypeReadRepository : IReadRepository<MediaType>
	{
		Task<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request);

		Task<List<MediaTypeWhiteListDto>> GetMediaTypeWhiteListAsync();
	}
}
