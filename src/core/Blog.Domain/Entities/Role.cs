namespace Blog.Domain.Entities
{
	public class Role : BaseEntity
	{
		public Role()
		{
			this.Users = new HashSet<UserRoles>();
		}

		public string Name { get; set; }

		public string Description { get; set; }

		public bool CanLogin { get; set; }

		public virtual ICollection<UserRoles> Users { get; set; }
	}
}
