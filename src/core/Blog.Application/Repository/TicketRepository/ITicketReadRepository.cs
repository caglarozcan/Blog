using Blog.Application.Dto.TagsDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface ITicketReadRepository : IReadRepository<Ticket>
{
	Task<PagingDataResponse<TagListDto>> ListAsync(DataListRequest request);
}
