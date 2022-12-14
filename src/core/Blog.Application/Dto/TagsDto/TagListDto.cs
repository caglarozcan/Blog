namespace Blog.Application.Dto.TagsDto;

public class TagListDto
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public DateTime CreatedDate { get; set; }

	public string Slug { get; set; }

	public byte Status { get; set; }
}
