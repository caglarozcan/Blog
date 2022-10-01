using Blog.Application.Dto;
using Blog.Application.Dto.CategoryDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(DbContext dbContext)
			: base(dbContext)
		{
		}

		public async Task<PagingDataResponse<CategoryListDto>> GetCategoryListAsync(DataListRequest request)
		{
			var query = Table.Select(s => new CategoryListDto()
			{
				Id = s.Id,
				Title = s.Title,
				Slug = s.Slug,
				Color = s.Color,
				Description = s.Description,
				Icon = s.Icon,
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

		public async Task<CategorySelectDto> GetCategorySelect(Guid? id)
		{
			var options = await Table.Where(c => !c.ParentId.HasValue).Select(s => new SelectOptionsDto()
			{
				Value = s.Id.ToString(),
				Text = s.Title
			}).ToListAsync();

			return new CategorySelectDto()
			{
				ParentId = id.HasValue ? id.Value : null,
				Options = options
			};
		}
	}
}
