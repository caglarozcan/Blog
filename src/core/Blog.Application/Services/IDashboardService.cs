using Blog.Application.Dto.DashboardDto;

namespace Blog.Application.Services;

public interface IDashboardService
{
	Task<GeneralStaticticDto> GetGeneralStatisticAsync();
}
