using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services
{
	public class ArticleService : BaseService, IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArticleService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
	}
}
