using Blog.Application.Dto.MediaDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository
{
	public interface IMediaReadRepository : IReadRepository<Media>
	{
		Task<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request);
	}
}
