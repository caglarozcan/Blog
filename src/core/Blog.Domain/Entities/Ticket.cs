namespace Blog.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            this.Articles = new HashSet<ArticleTickets>();
        }

        public string Title { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<ArticleTickets> Articles { get; set; }
    }
}
