namespace Blog.Application.Dto.SubscriberDto;

public class SubscriberListDto
{
	public Guid Id { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdateDate { get; set; }

	public byte Status { get; set; }
}
