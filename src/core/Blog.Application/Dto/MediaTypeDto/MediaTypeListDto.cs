namespace Blog.Application.Dto.MediaTypeDto
{
	public class MediaTypeListDto
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public string MimeType { get; set; }

		public string FileExtension { get; set; }

		public DateTime CreatedDate { get; set; }

		public byte Status { get; set; }
	}
}
