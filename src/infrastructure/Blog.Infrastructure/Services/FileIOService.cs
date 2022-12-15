using Blog.Application.Dto.SettingDto.BlogOptions;
using Blog.Application.Enums;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Runtime.Versioning;

namespace Blog.Infrastructure.Services;

public class FileIOService : IFileIOService
{
	private IUnitOfWork _unitOfWork { get; }
	private IAuthUserInfoService _authUserInfoService;
	private readonly FileUploadOptions _fileUploadOptions;

	public FileIOService(
		IUnitOfWork unitOfWork,
		IAuthUserInfoService authUserInfoService,
		IOptions<FileUploadOptions> fileUploadOptions)
	{
		this._unitOfWork = unitOfWork;
		this._authUserInfoService = authUserInfoService;
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
					resizeImageThumbnail(file.OpenReadStream(), uploadPath, newFileName, ImageResizeType.ResizeWithoutRatio);
					resizeImageMedium(file.OpenReadStream(), uploadPath, newFileName, ImageResizeType.ResizeWithoutRatio);
					resizeImageLarge(file.OpenReadStream(), uploadPath, newFileName, ImageResizeType.ResizeWithoutRatio);
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

	[SupportedOSPlatform("windows")]
	private void resizeImageThumbnail(Stream image, string uploadPath, string fileName, ImageResizeType imageResizeType)
	{
		if (imageResizeType == ImageResizeType.ResizeWithoutRatio)
			imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "thumbnail", fileName));
		else
			imageResizeRatio(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "thumbnail", fileName));
	}

	[SupportedOSPlatform("windows")]
	private void resizeImageMedium(Stream image, string uploadPath, string fileName, ImageResizeType imageResizeType)
	{
		if (imageResizeType == ImageResizeType.ResizeWithoutRatio)
			imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "middle", fileName));
		else
			imageResizeRatio(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "middle", fileName));
	}

	[SupportedOSPlatform("windows")]
	private void resizeImageLarge(Stream image, string uploadPath, string fileName, ImageResizeType imageResizeType)
	{
		if (imageResizeType == ImageResizeType.ResizeWithoutRatio)
			imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "large", fileName));
		else
			imageResizeRatio(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "large", fileName));
	}

	[SupportedOSPlatform("windows")]
	private Bitmap imageResize(Stream stream, int width, int height)
	{
		Image image = Image.FromStream(stream);
		Bitmap bitmap = new Bitmap(Image.FromStream(stream), width, height);
		using (Graphics graphics = Graphics.FromImage((Image)bitmap))
		{
			graphics.DrawImage(image, 0, 0, width, height);
			return bitmap;
		}
	}

	[SupportedOSPlatform("windows")]
	private Bitmap imageResizeRatio(Stream stream, int width, int height)
	{
		Image image = Image.FromStream(stream);
		Size size = new Size(width, height);

		int imageWidth = image.Width;
		int imageHeight = image.Height;

		double ratio = 0;
		double ratioWidth = (double)size.Width / (double)imageWidth;
		double ratioHeight = (double)size.Height / (double)imageHeight;

		if (ratioWidth < ratioHeight)
		{
			ratio = ratioWidth;
		}
		else
		{
			ratio = ratioHeight;
		}

		Size newSize = new Size((int)(imageWidth * ratio), (int)(imageHeight * ratio));

		Bitmap bitmap = new Bitmap(newSize.Width, newSize.Height);
		using (Graphics graphics = Graphics.FromImage((Image)bitmap))
		{
			graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
			return bitmap;
		}
	}
}
