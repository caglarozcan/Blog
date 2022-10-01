namespace Blog.Application.Dto.RoleDto
{
	public class RoleSelectDto
    {
		public Guid? RoleId { get; set; }

		public List<SelectOptionsDto> Options { get; set; }
	}
}
