using Blog.Application.Dto.SettingDto.BlogOptions;
using Blog.Application.Services;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Runtime.Versioning;

namespace Blog.Infrastructure.Services;

public class ImageResizeService : IImageResizeService
{
	private readonly FileUploadOptions _fileUploadOptions;

	public ImageResizeService(IOptions<FileUploadOptions> fileUploadOptions)
	{
		_fileUploadOptions = fileUploadOptions.Value;
	}

	[SupportedOSPlatform("windows")]
	public void ImageResizeLarge(Stream image, string uploadPath, string fileName)
	{
		imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "large", fileName));
	}

	[SupportedOSPlatform("windows")]
	public void ImageResizeMedium(Stream image, string uploadPath, string fileName)
	{
		imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "medium", fileName));
	}

	[SupportedOSPlatform("windows")]
	public void ImageResizeThumbnail(Stream image, string uploadPath, string fileName)
	{
		imageResize(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "thumbnail", fileName));
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
}
