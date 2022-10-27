using Blog.Application.Dto.SettingDto;

namespace Blog.Application.Services
{
	public interface ISettingService
	{
		Task<List<SettingGroupListDto>> GetSettingsAsync();
	}
}
