namespace Blog.Application.Dto.MediaDto;

public sealed class MediaListDto
{
	public Guid Id { get; set; }

	public required string Name { get; set; }

	public required string OriginalName { get; set; }

	public required string MimeType { get; set; }

	public required string Icon { get; set; }

	public required string UploadDir { get; set; }
}
