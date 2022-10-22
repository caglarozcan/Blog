using Blog.Application.Services;
using Blog.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection collection)
		{
			collection.AddTransient<IArticleService, ArticleService>();
			collection.AddTransient<IAuthenticationService, AuthenticationService>();
			collection.AddTransient<IAuthUserInfoService, AuthUserInfoService>();
			collection.AddTransient<ICategoryService, CategoryService>();
			collection.AddTransient<IHashService, HashService>();
			collection.AddTransient<IMailService, MailService>();
			collection.AddTransient<IMediaService, MediaService>();
			collection.AddTransient<IMediaTypeService, MediaTypeService>();
			collection.AddTransient<IRoleService, RoleService>();
			collection.AddTransient<ITextService, TextService>();
			collection.AddTransient<ITicketService, TicketService>();
			collection.AddTransient<IUserService, UserService>();
			collection.AddTransient<IFileIOService, FileIOService>();
			collection.AddTransient<ISettingService, SettingService>();
		}
	}
}
