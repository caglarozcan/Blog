namespace Blog.Domain.Entities
{
	public class UserRoles
	{
		public Guid UserId { get; set; }

		public Guid RoleId { get; set; }

		public virtual User User { get; set; }

		public virtual Role Role { get; set; }
	}
}
