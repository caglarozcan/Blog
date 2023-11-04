namespace Blog.Application.Dto.MediaTypeDto;

public sealed class MediaTypeSelectDto
{
	public Guid? MediaTypeId { get; set; }

	public List<SelectOptionsDto>? Options { get; set; }
}
