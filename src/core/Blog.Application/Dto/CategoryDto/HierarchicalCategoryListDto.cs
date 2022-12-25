namespace Blog.Application.Dto.CategoryDto;

public class HierarchicalCategoryListDto
{
	public HierarchicalCategoryListDto()
	{
		this.ChildCategories = new List<CategoryListDto>();
	}

	public Guid Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public string Icon { get; set; }

	public string Color { get; set; }

	public string Slug { get; set; }

	public List<CategoryListDto> ChildCategories { get; set; }
}
