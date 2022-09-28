using Blog.Domain.Entities;
using Blog.Persistence.EfContext.EntityMapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Persistence.EfContext
{
	public class EfBlogContext : DbContext
	{
		public EfBlogContext(DbContextOptions<EfBlogContext> option)
			: base(option)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region ConfigurationMap
			/*modelBuilder.ApplyConfiguration(new ArticleMap());
			modelBuilder.ApplyConfiguration(new CategoryMap());
			modelBuilder.ApplyConfiguration(new MediaMap());
			modelBuilder.ApplyConfiguration(new MediaTypeMap());
			modelBuilder.ApplyConfiguration(new TicketMap());
			modelBuilder.ApplyConfiguration(new RoleMap());
			modelBuilder.ApplyConfiguration(new UserMap());
			modelBuilder.ApplyConfiguration(new ArticleCategoriesMap());
			modelBuilder.ApplyConfiguration(new ArticleMediasMap());
			modelBuilder.ApplyConfiguration(new ArticleTicketsMap());
			modelBuilder.ApplyConfiguration(new UserRolesMap());*/

			//yukarıdaki gibi tek tek tanımlamak yerine aşağıdaki kod proje içerisinden ilgili konfigurasyon sınıflarını bulup buraya getirecek.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			#endregion

			#region Relations
			/*modelBuilder.Entity<ArticleCategories>(entitiy =>
			{
				entitiy.HasKey(k => new { k.ArticleId, k.CategoryId });

				entitiy.HasOne(o => o.Article)
					.WithMany(m => m.Categories)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleCategories_Article_Id");

				entitiy.HasOne(o => o.Category)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.CategoryId)
					.HasConstraintName("FK_ArticleCategories_Category_Id");
			});*/

			/*modelBuilder.Entity<ArticleMedias>(entitiy =>
			{
				entitiy.HasKey(k => new { k.ArticleId, k.MediaId });

				entitiy.HasOne(o => o.Article)
					.WithMany(m => m.Medias)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleMedias_Article_Id")
					.OnDelete(DeleteBehavior.Cascade);

				entitiy.HasOne(o => o.Media)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.MediaId)
					.HasConstraintName("FK_ArticleMedias_Media_Id")
					.OnDelete(DeleteBehavior.NoAction);
			});*/

			/*modelBuilder.Entity<ArticleTickets>(entitiy =>
			{
				entitiy.HasKey(k => new { k.ArticleId, k.TicketId });

				entitiy.HasOne(o => o.Article)
					.WithMany(m => m.Tickets)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleTickets_Article_Id");

				entitiy.HasOne(o => o.Ticket)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.TicketId)
					.HasConstraintName("FK_ArticleTickets_Ticket_Id");
			});*/

			/*modelBuilder.Entity<UserRoles>(entitiy =>
			{
				entitiy.HasKey(k => new { k.UserId, k.RoleId });

				entitiy.HasOne(o => o.User)
					.WithMany(m => m.Roles)
					.HasForeignKey(f => f.UserId)
					.HasConstraintName("FK_UserRoles_User_Id");

				entitiy.HasOne(o => o.Role)
					.WithMany(m => m.Users)
					.HasForeignKey(f => f.RoleId)
					.HasConstraintName("FK_UserRoles_Role_Id");
			});*/

			/*modelBuilder.Entity<Article>(entity =>
			{
				entity.HasOne(o => o.User)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.UserId)
					.HasConstraintName("FK_Article_User_Id");
			});*/

			/*modelBuilder.Entity<Media>(entity =>
			{
				entity.HasOne(o => o.User)
					.WithMany(m => m.Medias)
					.HasForeignKey(f => f.UserId)
					.HasConstraintName("FK_Media_User_Id");

				entity.HasOne(o => o.MediaType)
					.WithMany(m => m.Medias)
					.HasForeignKey(f => f.MediaTypeId)
					.HasConstraintName("FK_Media_MediaType_Id");
			});*/

			/*modelBuilder.Entity<Category>(entity =>
			{
				entity.HasOne(o => o.Parent)
				.WithMany(m => m.Childs)
				.HasForeignKey(f => f.ParentId)
				.HasConstraintName("FK_Category_Parent_Id")
				.OnDelete(DeleteBehavior.NoAction);
			});*/
			#endregion
		}

		#region DbSets
		public DbSet<Article> Articles { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Ticket> Tickets { get; set; }

		public DbSet<Media> Medias { get; set; }

		public DbSet<MediaType> MediaTypes { get; set; }

		public DbSet<ArticleCategories> ArticleCategories { get; set; }

		public DbSet<ArticleMedias> ArticleMedias { get; set; }

		public DbSet<ArticleTickets> ArticleTickets { get; set; }

		public DbSet<Role> Role { get; set; }

		public DbSet<UserRoles> UserRoles { get; set; }

		public DbSet<User> Users { get; set; }
		#endregion
	}
}
