using Blog.Application.Dto.MediaDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Buffers;

namespace Blog.Persistence.Repository;

public class MediaReadRepository : ReadRepository<Media>, IMediaReadRepository
{
	public MediaReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}

	public async Task<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request, Guid userId)
	{
		var query = Table.AsNoTracking().Include(i => i.MediaType).Where(m => m.UserId.Equals(userId)).Select(s => new MediaListDto()
		{
			Id	= s.Id,
			Name = s.Name,
			OriginalName = s.OriginalName,
			Icon = s.MediaType.Icon,
			MimeType = s.MediaType.MimeType,
			UploadDir = s.MediaType.UploadDir + "/thumbnail"
		});

		return await query.ToPagingData(request.PerData, request.Page);
	}

	public async Task<PagingDataResponse<MediaListDto>> GetFilteredMediaListAsync(DataListRequest request, Guid userId)
	{
		var query = Table.AsNoTracking().Include(i => i.MediaType).Where(m => 
			m.UserId.Equals(userId) 
			&& request.SearchValue.Contains(m.MediaType.FileExtension)
		).Select(s => new MediaListDto()
		{
			Id = s.Id,
			Name = s.Name,
			OriginalName = s.OriginalName,
			Icon = s.MediaType.Icon,
			MimeType = s.MediaType.MimeType,
			UploadDir = s.MediaType.UploadDir + "/thumbnail"
		});

		return await query.ToPagingData(request.PerData, request.Page);
	}
}
