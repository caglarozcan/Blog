using Blog.Application.Dto.SettingDto;
using Blog.Domain.Entities;

namespace Blog.Application.Repository
{
	public interface ISettingGroupReadRepository :IReadRepository<SettingGroup>
	{
		#region Read
		Task<List<BlogOptionsDto>> GetBlogOptionsAsync();

		Task<List<SettingGroupListDto>> GetSettingsAsync();
		#region
	}
}
