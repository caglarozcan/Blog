﻿using Blog.Application.Dto.SettingDto.BlogOptions;
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
	public void ImageResizeLargeRatio(Stream image, string uploadPath, string fileName)
	{
		imageResizeRatio(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "large", fileName));
	}

	[SupportedOSPlatform("windows")]
	public void ImageResizeMediumRatio(Stream image, string uploadPath, string fileName)
	{
		imageResizeRatio(image, _fileUploadOptions.ImageSmallWidth, _fileUploadOptions.ImageSmallHeight).Save(Path.Combine(uploadPath, "large", fileName));
	}

	[SupportedOSPlatform("windows")]
	public void ImageResizeThumbnailRatio(Stream image, string uploadPath, string fileName)
	{
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
