using Blog.Application.Dto.SubscriberDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface ISubscriberReadRepository : IReadRepository<Subscriber>
{
	Task<PagingDataResponse<SubscriberListDto>> GetSubscriberListAsync(DataListRequest request);
}
