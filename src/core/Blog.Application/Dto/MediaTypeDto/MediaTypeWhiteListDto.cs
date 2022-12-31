namespace Blog.Application.Dto.MediaTypeDto;

public sealed class MediaTypeWhiteListDto
{
	public Guid Id { get; set; }

	public string MimeType { get; set; }

	public string FileExtension { get; set; }

	public string UploadDir { get; set; }
}
