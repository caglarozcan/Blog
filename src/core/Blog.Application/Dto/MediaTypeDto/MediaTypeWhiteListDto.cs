namespace Blog.Application.Dto.MediaTypeDto;

public sealed class MediaTypeWhiteListDto
{
	public Guid Id { get; set; }

	public required string MimeType { get; set; }

	public required string FileExtension { get; set; }

	public required string UploadDir { get; set; }
}
