namespace Blog.Application.Dto.CategoryDto;

public sealed class CategorySelectDto
{
	public Guid? ParentId { get; set; }

	public List<SelectOptionsDto> Options { get; set; }
}
