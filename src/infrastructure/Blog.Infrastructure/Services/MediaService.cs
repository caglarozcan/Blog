using Blog.Application.Dto.MediaDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace Blog.Infrastructure.Services;

public class MediaService : BaseService, IMediaService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAuthUserInfoService _authUserInfoService;
	private IFileIOService _fileIOService;

	public MediaService(IUnitOfWork unitOfWork, IFileIOService fileIOService, IAuthUserInfoService authUserInfoService)
	{
		this._unitOfWork = unitOfWork;
		this._fileIOService = fileIOService;
		this._authUserInfoService = authUserInfoService;
	}

	#region Functions
	#region Create
	public async Task<Response> FileUploadAsync(IFormFile file)
	{
		if (file == null)
			return new Response("Yüklenecek dosya seçilmeli", false);

		return await _fileIOService.Create(file);
	}
	#endregion

	#region Read
	public async Task<PagingDataResponse<MediaListDto>> GetMediaListAsync(DataListRequest request)
	{
		return await _unitOfWork.MediaReadRepository.GetMediaListAsync(request, _authUserInfoService.Id);
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
