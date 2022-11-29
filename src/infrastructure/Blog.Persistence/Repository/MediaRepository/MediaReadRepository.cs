using Blog.Application.Dto.MediaDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class MediaReadRepository : ReadRepository<Media>, IMediaReadRepository
	{
		private readonly IAuthUserInfoService _authUserInfoService;

		public MediaReadRepository(IAuthUserInfoService authUserInfoService, DbContext dbContext) 
			: base(dbContext)
		{
			_authUserInfoService = authUserInfoService;
		}

		public async Task<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request)
		{
			var query = Table.Include(i => i.MediaType).Where(m => m.UserId.Equals(_authUserInfoService.Id)).Select(s => new MediaListDto()
			{
				Id	= s.Id,
				Name = s.Name,
				OriginalName = s.OriginalName,
				Icon = s.MediaType.Icon,
				MimeType = s.MediaType.MimeType,
				UploadDir = s.MediaType.UploadDir
			});

			return await query.ToPagingData(request.PerData, request.Page);
		}
	}
}
