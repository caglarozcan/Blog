namespace Blog.Application.Dto.MediaDto
{
	public class MediaListDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string OriginalName { get; set; }

		public string MimeType { get; set; }

		public string Icon { get; set; }

		public string UploadDir { get; set; }
	}
}
