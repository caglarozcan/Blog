using Blog.Application.Dto.SubscriberDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Blog.Persistence.Specification.Specifications.SubscriberSpecifications;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class SubscriberReadRepository : ReadRepository<Subscriber>, ISubscriberReadRepository
{
	public SubscriberReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}

	public async Task<PagingDataResponse<SubscriberListDto>> GetSubscriberListAsync(DataListRequest request)
	{
		SearchSubscriberSpecification searchSubscriberSpecification = new(request.SearchValue);

		var query = Table.AsNoTracking().Where(searchSubscriberSpecification.ToExpression()).Select(s => new SubscriberListDto()
		{
			Id = s.Id,
			FirstName = s.FirsName,
			LastName = s.LastName,
			Email = s.Email,
			CreatedDate = s.CreatedDate,
			UpdateDate = s.UpdatedDate,
			Status = s.Status
		});

		if (request.SortType.HasValue)
		{
			query = query.OrderByPredicate(request.SortIndex!.Value, request.SortType.Value);
		}

		return await query.ToPagingData(request.PerData, request.Page);
	}
}
