using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Persistence.EfContext;

public class EfBlogContext : DbContext
{
	public EfBlogContext(DbContextOptions<EfBlogContext> option)
		: base(option)
	{ }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		#region ConfigurationMap
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		#endregion
	}

	#region DbSets
	public DbSet<Article> Articles { get; set; }

	public DbSet<Bibliography> Bibliographies { get; set; }

	public DbSet<Category> Categories { get; set; }

	public DbSet<Comment> Comments { get; set; }

	public DbSet<Ticket> Tickets { get; set; }

	public DbSet<Media> Medias { get; set; }

	public DbSet<MediaType> MediaTypes { get; set; }

	public DbSet<ArticleBibliographies> ArticleBibliographies { get; set; }

	public DbSet<ArticleCategories> ArticleCategories { get; set; }

	public DbSet<ArticleMedias> ArticleMedias { get; set; }

	public DbSet<ArticleTickets> ArticleTickets { get; set; }

	public DbSet<Role> Role { get; set; }

	public DbSet<SettingGroup> SettingGroups { get; set; }

	public DbSet<Settings> Settings { get; set; }

	public DbSet<Subscriber> Subscribers { get; set; }

	public DbSet<UserRoles> UserRoles { get; set; }

	public DbSet<User> Users { get; set; }
	#endregion
}
