using Blog.Application.Repository;

namespace Blog.Application.UnitOfWork
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IArticleReadRepository ArticleReadRepository { get; }
		IArticleWriteRepository ArticleWriteRepository { get; }

		ICategoryReadRepository CategoryReadRepository { get; }
		ICategoryWriteRepository CategoryWriteRepository { get; }

		IMediaReadRepository MediaReadRepository { get; }
		IMediaWriteRepository MediaWriteRepository { get; }

		IMediaTypeReadRepository MediaTypeReadRepository { get; }
		IMediaTypeWriteRepository MediaTypeWriteRepository { get; }

		ITicketReadRepository TicketReadRepository { get; }
		ITicketWriteRepository TicketWriteRepository { get; }

		IRoleReadRepository RoleReadRepository { get; }
		IRoleWriteRepository RoleWriteRepository { get; }

		IUserReadRepository UserReadRepository { get; }
		IUserWriteRepository UserWriteRepository { get; }

		Task<int> SaveAsync();
	}
}
