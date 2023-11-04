using Blog.Application.Repository;
using Blog.Application.UnitOfWork;
using Blog.Persistence.EfContext;
using Blog.Persistence.Repository;

namespace Blog.Persistence;

public class UnitOfWork : IUnitOfWork
{
	private readonly EfBlogContext _dbContext;

	private readonly IArticleReadRepository _articleReadRepository;
	private readonly IArticleWriteRepository _articleWriteRepository;
	private readonly IBibliographyReadRepository _bibliographyReadRepository;
	private readonly IBibliographyWriteRepository _bibliographyWriteRepository;
	private readonly ICategoryReadRepository _categoryReadRepository;
	private readonly ICategoryWriteRepository _categoryWriteRepository;
	private readonly ICommentReadRepository _commentReadRepository;
	private readonly ICommentWriteRepository _commentWriteRepository;
	private readonly IMediaReadRepository _mediaReadRepository;
	private readonly IMediaWriteRepository _mediaWriteRepository;
	private readonly IMediaTypeReadRepository _mediaTypeReadRepository;
	private readonly IMediaTypeWriteRepository _mediaTypeWriteRepository;
	private readonly IRoleReadRepository _roleReadRepository;
	private readonly IRoleWriteRepository _roleWriteRepository;
	private readonly ISettingGroupReadRepository _settingGroupReadRepository;
	private readonly ISettingGroupWriteRespository _settingGroupWriteRespository;
	private readonly ISettingsReadRepository _settingsReadRepository;
	private readonly ISettingsWriteRepository _settingsWriteRepository;
	private readonly ISubscriberReadRepository _subscriberReadRepository;
	private readonly ISubscriberWriteRepository _subscriberWriteRepository;
	private readonly ITicketReadRepository _ticketReadRepository;
	private readonly ITicketWriteRepository _ticketWriteRepository;
	private readonly IUserReadRepository _userReadRepository;
	private readonly IUserWriteRepository _userWriteRepository;
	

	public UnitOfWork(EfBlogContext dbContext)
	{
		this._dbContext = dbContext;
	}

	public IArticleReadRepository ArticleReadRepository => _articleReadRepository ?? new ArticleReadRepository(_dbContext);
	public IArticleWriteRepository ArticleWriteRepository => _articleWriteRepository ?? new ArticleWriteRepository(_dbContext);

	public IBibliographyReadRepository BibliographyReadRepository => _bibliographyReadRepository ?? new BibliographyReadRepository(_dbContext);
	public IBibliographyWriteRepository BibliographyWriteRepository => _bibliographyWriteRepository ?? new BibliographyWriteRepository(_dbContext);

	public ICategoryReadRepository CategoryReadRepository => _categoryReadRepository ?? new CategoryReadRepository(_dbContext);
	public ICategoryWriteRepository CategoryWriteRepository => _categoryWriteRepository ?? new CategoryWriteRepository(_dbContext);

	public ICommentReadRepository CommentReadRepository => _commentReadRepository ?? new CommentReadRepository(_dbContext);
	public ICommentWriteRepository CommentWriteRepository => _commentWriteRepository ?? new CommentWriteRepository(_dbContext);

	public IMediaReadRepository MediaReadRepository => _mediaReadRepository ?? new MediaReadRepository(_dbContext);
	public IMediaWriteRepository MediaWriteRepository => _mediaWriteRepository ?? new MediaWriteRepository(_dbContext);

	public IMediaTypeReadRepository MediaTypeReadRepository => _mediaTypeReadRepository ?? new MediaTypeReadRepository(_dbContext);
	public IMediaTypeWriteRepository MediaTypeWriteRepository => _mediaTypeWriteRepository ?? new MediaTypeWriteRepository(_dbContext);

	public IRoleReadRepository RoleReadRepository => _roleReadRepository ?? new RoleReadRepository(_dbContext);
	public IRoleWriteRepository RoleWriteRepository => _roleWriteRepository ?? new RoleWriteRepository(_dbContext);

	public ISettingGroupReadRepository SettingGroupReadRepository => _settingGroupReadRepository ?? new SettingGroupReadRepository(_dbContext);
	public ISettingGroupWriteRespository SettingGroupWriteRespository => _settingGroupWriteRespository ?? new SettingGroupWriteRepository(_dbContext);

	public ISettingsReadRepository SettingsReadRepository => _settingsReadRepository ?? new SettingsReadRepository(_dbContext);
	public ISettingsWriteRepository SettingsWriteRepository => _settingsWriteRepository ?? new SettingsWriteRepository(_dbContext);

	public ISubscriberReadRepository SubscriberReadRepository => _subscriberReadRepository ?? new SubscriberReadRepository(_dbContext);
	public ISubscriberWriteRepository SubscriberWriteRepository => _subscriberWriteRepository ?? new SubscriberWriteRepository(_dbContext);

	public ITicketReadRepository TicketReadRepository => _ticketReadRepository ?? new TicketReadRepository(_dbContext);
	public ITicketWriteRepository TicketWriteRepository => _ticketWriteRepository ?? new TicketWriteRepository(_dbContext);

	public IUserReadRepository UserReadRepository => _userReadRepository ?? new UserReadRepository(_dbContext);
	public IUserWriteRepository UserWriteRepository => _userWriteRepository ?? new UserWriteRepository(_dbContext);

	public async ValueTask<int> SaveAsync(CancellationToken cancellationToken = default)
	{
		return await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async ValueTask DisposeAsync()
	{
		await _dbContext.DisposeAsync();
	}
}
