namespace Blog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Articles = new HashSet<ArticleCategories>();
            this.Childs = new HashSet<Category>();
        }

        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public string Slug { get; set; }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Childs { get; set; }

        public virtual ICollection<ArticleCategories> Articles { get; set; }
    }
}
