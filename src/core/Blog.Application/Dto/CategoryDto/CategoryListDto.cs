namespace Blog.Application.Dto.CategoryDto;

public sealed class CategoryListDto
{
	public Guid Id { get; set; }

	public Guid? ParentId { get; set; }

	public required string Title { get; set; }

	public required string Description { get; set; }

	public required string Icon { get; set; }

	public required string Color { get; set; }

	public required string Slug { get; set; }

	public DateTime CreatedDate { get; set; }

	public byte Status { get; set; }
}
