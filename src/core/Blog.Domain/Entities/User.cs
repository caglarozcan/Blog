namespace Blog.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Medias = new HashSet<Media>();
            this.Roles = new HashSet<UserRoles>();
        }

		public string Name { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<UserRoles> Roles { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Media> Medias { get; set; }
    }
}
