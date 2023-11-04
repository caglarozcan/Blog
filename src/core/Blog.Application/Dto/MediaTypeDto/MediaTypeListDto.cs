namespace Blog.Application.Dto.MediaTypeDto;

public sealed class MediaTypeListDto
{
	public Guid Id { get; set; }

	public required string Title { get; set; }

	public required string MimeType { get; set; }

	public required string FileExtension { get; set; }

	public DateTime CreatedDate { get; set; }

	public byte Status { get; set; }
}
