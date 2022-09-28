using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class ArticleCategoriesMap : IEntityTypeConfiguration<ArticleCategories>
	{
		public void Configure(EntityTypeBuilder<ArticleCategories> builder)
		{
			builder.ToTable(nameof(ArticleCategories));

			builder.Property(p => p.ArticleId)
				.HasColumnName("ArticleId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.CategoryId)
				.HasColumnName("CategoryId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
				.IsRequired(true);

			#region Keys and Foreignkeys
			builder.HasKey(k => new { k.ArticleId, k.CategoryId });

			builder.HasOne(o => o.Article)
					.WithMany(m => m.Categories)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleCategories_Article_Id");

			builder.HasOne(o => o.Category)
				.WithMany(m => m.Articles)
				.HasForeignKey(f => f.CategoryId)
				.HasConstraintName("FK_ArticleCategories_Category_Id");
			#endregion
		}
	}
}
