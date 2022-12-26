namespace Blog.Domain.Entities;

public class ArticleBibliographies
{
	public Guid ArticleId { get; set; }

	public Guid BibliographyId { get; set; }

	public virtual Article Article { get; set; }

	public virtual Bibliography Bibliography { get; set; }
}
