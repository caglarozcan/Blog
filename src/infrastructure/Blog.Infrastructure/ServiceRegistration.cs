using Blog.Application.Services;
using Blog.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;

public static class ServiceRegistration
{
	public static void AddInfrastructureServices(this IServiceCollection collection)
	{
		collection.AddTransient<IArticleService, ArticleService>();
		collection.AddTransient<IAuthenticationService, AuthenticationService>();
		collection.AddTransient<IAuthUserInfoService, AuthUserInfoService>();
		collection.AddTransient<IBibliographyService, BibliographyService>();
		collection.AddTransient<ICategoryService, CategoryService>();
		collection.AddTransient<ICommentService, CommentService>();
		collection.AddTransient<IDashboardService, DashboardService>();
		collection.AddTransient<IFileIOService, FileIOService>();
		collection.AddTransient<IHashService, HashService>();
		collection.AddTransient<IImageResizeService, ImageResizeService>();
		collection.AddTransient<IMailService, MailService>();
		collection.AddTransient<IMediaService, MediaService>();
		collection.AddTransient<IMediaTypeService, MediaTypeService>();
		collection.AddTransient<IRoleService, RoleService>();
		collection.AddTransient<ITextService, TextService>();
		collection.AddTransient<ITicketService, TicketService>();
		collection.AddTransient<ISettingService, SettingService>();
		collection.AddTransient<ISubscriberService, SubscriberService>();
		collection.AddTransient<IUserService, UserService>();

	}
}
