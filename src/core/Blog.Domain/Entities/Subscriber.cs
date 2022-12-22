namespace Blog.Domain.Entities;

public class Subscriber : BaseEntity
{
	public string FirsName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }
}
