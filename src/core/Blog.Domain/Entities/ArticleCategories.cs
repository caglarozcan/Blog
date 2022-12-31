namespace Blog.Domain.Entities;

public class ArticleCategories
{
	public Guid ArticleId { get; set; }

	public Guid CategoryId { get; set; }

	public virtual Article Article { get; set; }

	public virtual Category Category { get; set; }
}
