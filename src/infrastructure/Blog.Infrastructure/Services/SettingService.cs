using Blog.Application.Dto.SettingDto;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services
{
	public class SettingService : ISettingService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SettingService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task<List<SettingGroupListDto>> GetSettingsAsync()
		{
			var settings = await _unitOfWork.SettingGroupReadRepository.GetAllAsync(includes: i => i.Settings);

			return settings.Select(s => new SettingGroupListDto()
			{
				Id = s.Id,
				Name = s.Name,
				Description = s.Description,
				Settings = s.Settings.Select(t => new SettingsListDto()
				{
					Id = t.Id,
					SettingGroupId = t.SettingGroupId,
					Name = t.Name,
					Value = t.Value
				}).ToList()
			}).ToList();
		}
	}
}
