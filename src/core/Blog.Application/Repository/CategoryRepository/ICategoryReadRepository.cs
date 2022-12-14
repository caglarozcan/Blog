using Blog.Application.Dto.CategoryDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface ICategoryReadRepository : IReadRepository<Category>
{
	Task<PagingDataResponse<CategoryListDto>> GetCategoryListAsync(DataListRequest request);

	Task<CategorySelectDto> GetCategorySelect(Guid? id);
}
