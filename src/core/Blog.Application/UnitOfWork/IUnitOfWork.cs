using Blog.Application.Repository;

namespace Blog.Application.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
	IArticleReadRepository ArticleReadRepository { get; }
	IArticleWriteRepository ArticleWriteRepository { get; }

	ICategoryReadRepository CategoryReadRepository { get; }
	ICategoryWriteRepository CategoryWriteRepository { get; }

	ICommentReadRepository CommentReadRepository { get; }
	ICommentWriteRepository CommentWriteRepository { get; }

	IMediaReadRepository MediaReadRepository { get; }
	IMediaWriteRepository MediaWriteRepository { get; }

	IMediaTypeReadRepository MediaTypeReadRepository { get; }
	IMediaTypeWriteRepository MediaTypeWriteRepository { get; }

	ITicketReadRepository TicketReadRepository { get; }
	ITicketWriteRepository TicketWriteRepository { get; }

	IRoleReadRepository RoleReadRepository { get; }
	IRoleWriteRepository RoleWriteRepository { get; }

	ISettingGroupReadRepository SettingGroupReadRepository { get; }
	ISettingGroupWriteRespository SettingGroupWriteRespository { get; }

	ISettingsReadRepository SettingsReadRepository { get; }
	ISettingsWriteRepository SettingsWriteRepository { get; }

	ISubscriberReadRepository SubscriberReadRepository { get; }
	ISubscriberWriteRepository SubscriberWriteRepository { get; }

	IUserReadRepository UserReadRepository { get; }
	IUserWriteRepository UserWriteRepository { get; }

	Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
