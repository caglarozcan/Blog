namespace Blog.Application.Dto.SubscriberDto;

public sealed class SubscriberListDto
{
	public Guid Id { get; set; }

	public required string FirstName { get; set; }

	public required string LastName { get; set; }

	public required string Email { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdateDate { get; set; }

	public byte Status { get; set; }
}
