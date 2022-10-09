using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	internal class MediaTypeReadRepository : ReadRepository<MediaType>, IMediaTypeReadRepository
	{
		public MediaTypeReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}

		public async Task<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request)
		{
			var query = Table.Select(s => new MediaTypeListDto()
			{
				Id = s.Id,
				Title = s.Title,
				MimeType = s.MimeType,
				FileExtension = s.FileExtension,
				CreatedDate = s.CreatedDate,
				Status = s.Status
			});

			if (!String.IsNullOrWhiteSpace(request.SearchValue))
			{
				query = query.WherePredicate(request.SearchValue);
			}

			if (request.SortType.HasValue)
			{
				query = query.OrderByPredicate(request.SortIndex.Value, request.SortType.Value);
			}

			return await query.ToPagingData(request.PerData, request.Page);
		}
	}
}
