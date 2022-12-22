using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services;

public class SubscriberService : BaseService, ISubscriberService
{
	private readonly IUnitOfWork _unitOfWork;

	public SubscriberService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
}
