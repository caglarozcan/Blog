using Blog.Application.Dto.SettingDto.BlogOptions;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Runtime.Versioning;

namespace Blog.Infrastructure.Services;

public class FileIOService : IFileIOService
{
	private IUnitOfWork _unitOfWork { get; }
	private IAuthUserInfoService _authUserInfoService;
	private IImageResizeService _imageResizeService;
	private readonly FileUploadOptions _fileUploadOptions;

	public FileIOService(
		IUnitOfWork unitOfWork,
		IAuthUserInfoService authUserInfoService,
		IImageResizeService imageResizeService,
		IOptions<FileUploadOptions> fileUploadOptions)
	{
		_unitOfWork = unitOfWork;
		_authUserInfoService = authUserInfoService;
		_imageResizeService = imageResizeService;
		_fileUploadOptions = fileUploadOptions.Value;
	}

	#region Info
	/**
	 * 1. Buraya gelen dosya bilgilerinin validation işleminden geçirilmiş olduğu varsayılır.
	 */
	#endregion

	public async ValueTask<Response> Copy(Guid id)
	{
		throw new NotImplementedException();
	}

	[SupportedOSPlatform("windows")]
	public async ValueTask<Response> Create(IFormFile file)
	{
		if (!(file.Length > 0))
			return new Response("Dosya seçmelisiniz.", false);

		var mimeTypeWhiteList = await _unitOfWork.MediaTypeReadRepository.GetMediaTypeWhiteListAsync();

		if (!mimeTypeWhiteList.Any(m => m.MimeType.Equals(file.ContentType)))
			return new Response(String.Concat(file.ContentType, " bu türde dosya yüklenemez."), false);

		var fileInfo = mimeTypeWhiteList.FirstOrDefault(m => m.MimeType.Equals(file.ContentType));
		string newFileName = String.Concat(Guid.NewGuid().ToString(), fileInfo.FileExtension);

		string uploadPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _fileUploadOptions.UploadPath, fileInfo.UploadDir.Replace("/", "\\")));
		string fullPath = file.ContentType.StartsWith("image") ? Path.Combine(uploadPath, "original", newFileName) : Path.Combine(uploadPath, newFileName);

		using (var stream = File.Create(fullPath))
		{
			await file.CopyToAsync(stream);
		}

		await _unitOfWork.MediaWriteRepository.InsertAsync(new Domain.Entities.Media()
		{
			CreatedDate = DateTime.Now,
			Description = "Blog dosyası.",
			MediaTypeId = fileInfo.Id,
			Name = newFileName,
			OriginalName = file.FileName,
			UserId = _authUserInfoService.Id
		});

		await _unitOfWork.SaveAsync();

		if (file.ContentType.StartsWith("image"))
		{
			if (_fileUploadOptions.ThumbIsRatioResize)
				_imageResizeService.ImageResizeThumbnailRatio(file.OpenReadStream(), uploadPath, newFileName);
			else
				_imageResizeService.ImageResizeThumbnail(file.OpenReadStream(), uploadPath, newFileName);

			if (_fileUploadOptions.MediumIsRatioResize)
				_imageResizeService.ImageResizeMediumRatio(file.OpenReadStream(), uploadPath, newFileName);
			else
				_imageResizeService.ImageResizeMedium(file.OpenReadStream(), uploadPath, newFileName);

			if (_fileUploadOptions.LargeIsRatioResize)
				_imageResizeService.ImageResizeLargeRatio(file.OpenReadStream(), uploadPath, newFileName);
			else
				_imageResizeService.ImageResizeLarge(file.OpenReadStream(), uploadPath, newFileName);
		}

		return new Response("Dosya başarıyla yüklendi.", true);
	}

	public async ValueTask<Response> Delete(Guid id)
	{
		throw new NotImplementedException();
	}

	public async ValueTask<Response> Rename(Guid id, string name)
	{
		throw new NotImplementedException();
	}
}
