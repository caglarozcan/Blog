namespace Blog.Domain.Entities;

public class Bibliography : BaseEntity
{
	public Bibliography()
	{
		this.Articles = new HashSet<ArticleBibliographies>();
	}

	public Guid UserId { get; set; }

	public string Title { get; set; }

	public string Url { get; set; }

	public virtual User User { get; set; }

	public virtual ICollection<ArticleBibliographies> Articles { get; set; }
}
