namespace Blog.Application.Services;

public interface IImageResizeService
{
	void ImageResizeThumbnail(Stream image, string uploadPath, string fileName);

	void ImageResizeMedium(Stream image, string uploadPath, string fileName);
	
	void ImageResizeLarge(Stream image, string uploadPath, string fileName);
}
