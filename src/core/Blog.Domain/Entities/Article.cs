namespace Blog.Domain.Entities
{
    public class Article : BaseEntity
    {
        public Article()
        {
            this.Categories = new HashSet<ArticleCategories>();
            this.Bibliographies = new HashSet<ArticleBibliographies>();
            this.Tickets = new HashSet<ArticleTickets>();
            this.Medias = new HashSet<ArticleMedias>();
            this.Comments = new HashSet<Comment>();
        }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int Hit { get; set; }

        public bool IsPinned { get; set; }

        public string Slug { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ArticleCategories> Categories { get; set; }

        public virtual ICollection<ArticleBibliographies> Bibliographies { get; set; }

        public virtual ICollection<ArticleTickets> Tickets { get; set; }

        public virtual ICollection<ArticleMedias> Medias { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
