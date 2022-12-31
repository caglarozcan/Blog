namespace Blog.Application.Dto.CategoryDto;

public sealed class CategoryListDto
{
	public Guid Id { get; set; }

	public Guid? ParentId { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public string Icon { get; set; }

	public string Color { get; set; }

	public string Slug { get; set; }

	public DateTime CreatedDate { get; set; }

	public byte Status { get; set; }
}
