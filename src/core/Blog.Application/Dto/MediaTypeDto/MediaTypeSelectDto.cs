namespace Blog.Application.Dto.MediaTypeDto
{
	public class MediaTypeSelectDto
	{
		public Guid? MediaTypeId { get; set; }

		public List<SelectOptionsDto> Options { get; set; }
	}
}
