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
		this._unitOfWork = unitOfWork;
		this._authUserInfoService = authUserInfoService;
		this._imageResizeService = imageResizeService;
		this._fileUploadOptions = fileUploadOptions.Value;
	}

	#region Info
	/**
	 * 1. Buraya gelen dosya bilgilerinin validation işleminden geçirilmiş olduğu varsayılır.
	 */
	#endregion

	public async Task<Response> Copy(Guid id)
	{
		throw new NotImplementedException();
	}

	[SupportedOSPlatform("windows")]
	public async Task<Response> Create(IFormFile file)
	{
		if (file.Length > 0)
		{
			var mimeTypeWhiteList = await _unitOfWork.MediaTypeReadRepository.GetMediaTypeWhiteListAsync();

			if (mimeTypeWhiteList.Any(m => m.MimeType.Equals(file.ContentType)))
			{
				var fileInfo = mimeTypeWhiteList.FirstOrDefault(m => m.MimeType.Equals(file.ContentType));
				string newFileName = String.Concat(Guid.NewGuid().ToString(), fileInfo.FileExtension);

				string uploadPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _fileUploadOptions.UploadPath, fileInfo.UploadDir.Replace("/", "\\")));
				string fullPath = Path.Combine(uploadPath, "original", newFileName);

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
			else
			{
				return new Response(String.Concat(file.ContentType, " bu türde dosya yüklenemez."), false);
			}
		}
		else
		{
			return new Response("Dosya seçmelisiniz.", false);
		}
	}

	public async Task<Response> Delete(Guid id)
	{
		throw new NotImplementedException();
	}

	public async Task<Response> Rename(Guid id, string name)
	{
		throw new NotImplementedException();
	}
}
