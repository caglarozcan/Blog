using Blog.Application.Dto.TagsDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Blog.Persistence.Specification.Specifications.TicketSpecifications;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class TicketReadRepository : ReadRepository<Ticket>, ITicketReadRepository
	{
		public TicketReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}

		public async Task<PagingDataResponse<TagListDto>> ListAsync(DataListRequest request)
		{
			SearchTicketSpecification spec = new(request.SearchValue);

			var query = Table.Where(spec.ToExpression()).Select(s => new TagListDto()
			{
				Id = s.Id,
				Title = s.Title,
				CreatedDate = s.CreatedDate,
				Slug = s.Slug,
				Status = s.Status
			});

			if (request.SortType.HasValue)
			{
				query = query.OrderByPredicate(request.SortIndex.Value, request.SortType.Value);
			}

			return await query.ToPagingData(request.PerData, request.Page);
		}
	}
}
