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
			return await _unitOfWork.SettingGroupReadRepository.GetSettingsAsync();
		}
	}
}
