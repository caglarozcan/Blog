namespace Blog.Domain.Entities;

public class ArticleMedias
{
	public Guid ArticleId { get; set; }

	public Guid MediaId { get; set; }

	public virtual Article Article { get; set; }

	public virtual Media Media { get; set; }
}
