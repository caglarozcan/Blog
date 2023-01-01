using Blog.Application.Dto.BibliographyDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Blog.Persistence.Specification.Specifications.BibliographySpecifications;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class BibliographyReadRepository : ReadRepository<Bibliography>, IBibliographyReadRepository
{
	public BibliographyReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}

	public async Task<PagingDataResponse<BibliographyListDto>> GetBibliographyListAsync(DataListRequest request)
	{
		SearchBibliographySpecification searchBibliographySpecification = new(request.SearchValue);

		var query = Table.Include(i => i.User).AsNoTracking().Where(searchBibliographySpecification.ToExpression()).Select(s => new BibliographyListDto()
		{
			Id = s.Id,
			Title = s.Title,
			Url = s.Url,
			CreatedDate = s.CreatedDate,
			Status = s.Status,
			UserName = s.User.Name + " " + s.User.LastName
		});

		if (request.SortType.HasValue)
		{
			query = query.OrderByPredicate(request.SortIndex.Value, request.SortType.Value);
		}

		return await query.ToPagingData(request.PerData, request.Page);
	}
}
