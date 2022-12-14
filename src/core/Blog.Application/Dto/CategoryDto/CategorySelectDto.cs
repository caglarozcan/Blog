namespace Blog.Application.Dto.CategoryDto;

public class CategorySelectDto
{
	public Guid? ParentId { get; set; }

	public List<SelectOptionsDto> Options { get; set; }
}
