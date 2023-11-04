namespace Blog.Application.Dto.CategoryDto;

public sealed class HierarchicalCategoryListDto
{
	public HierarchicalCategoryListDto()
	{
		this.ChildCategories = new List<CategoryListDto>();
	}

	public Guid Id { get; set; }

	public required string Title { get; set; }

	public required string Description { get; set; }

	public required string Icon { get; set; }

	public required string Color { get; set; }

	public required string Slug { get; set; }

	public List<CategoryListDto> ChildCategories { get; set; }
}
