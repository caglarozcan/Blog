using Blog.Application.Dto.DashboardDto;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services;

public class DashboardService : IDashboardService
{
	private readonly IUnitOfWork _unitOfWork;

	public DashboardService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async ValueTask<GeneralStaticticDto> GetGeneralStatisticAsync()
	{
		GeneralStaticticDto generalStatictic = new();
		generalStatictic.ArticleCount = await _unitOfWork.ArticleReadRepository.CountAsync(null);
		generalStatictic.MediaCount = await _unitOfWork.MediaReadRepository.CountAsync(null);
		generalStatictic.CommentCount = 0;
		generalStatictic.UserCount = await _unitOfWork.UserReadRepository.CountAsync(null);

		return generalStatictic;
	}
}
