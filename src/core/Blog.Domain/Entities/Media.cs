namespace Blog.Domain.Entities;

public class Media : BaseEntity
{
    public Media()
    {
        this.Articles = new HashSet<ArticleMedias>();
    }

    public Guid UserId { get; set; }

    public Guid MediaTypeId { get; set; }

    public string Name { get; set; }

    public string OriginalName { get; set; }

    public string Description { get; set; }

    public virtual User User { get; set; }

    public virtual MediaType MediaType { get; set; }

    public virtual ICollection<ArticleMedias> Articles { get; set; }
}
