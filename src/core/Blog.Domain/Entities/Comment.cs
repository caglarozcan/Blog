namespace Blog.Domain.Entities;

public class Comment : BaseEntity
{
    public Comment()
    {
        this.Childs = new HashSet<Comment>();
    }

    public Guid ArticleId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ParentCommentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Content { get; set; }

    public virtual Article Article { get; set; }

    public virtual User User { get; set; }

    public virtual Comment ParentComment { get; set; }

    public virtual ICollection<Comment> Childs { get; set; }
}
