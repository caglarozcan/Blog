namespace Blog.Application.Dto.BibliographyDto;

public sealed class BibliographyListDto
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public string Url { get; set; }

	public string UserName { get; set; }

	public DateTime CreatedDate { get; set; }

	public byte Status { get; set; }
}
