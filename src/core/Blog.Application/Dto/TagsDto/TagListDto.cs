namespace Blog.Application.Dto.TagsDto;

public sealed class TagListDto
{
	public Guid Id { get; set; }

	public required string Title { get; set; }

	public DateTime CreatedDate { get; set; }

	public string? Slug { get; set; }

	public byte Status { get; set; }
}
