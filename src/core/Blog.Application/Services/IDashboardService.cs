using Blog.Application.Dto.DashboardDto;

namespace Blog.Application.Services;

public interface IDashboardService
{
	ValueTask<GeneralStaticticDto> GetGeneralStatisticAsync();
}
