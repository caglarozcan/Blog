using Blog.Application.Dto.BibliographyDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface IBibliographyReadRepository : IReadRepository<Bibliography>
{
	Task<PagingDataResponse<BibliographyListDto>> GetBibliographyListAsync(DataListRequest request);
}
