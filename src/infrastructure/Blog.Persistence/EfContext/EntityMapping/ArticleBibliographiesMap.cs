using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class ArticleBibliographiesMap : IEntityTypeConfiguration<ArticleBibliographies>
{
	public void Configure(EntityTypeBuilder<ArticleBibliographies> builder)
	{
		builder.ToTable(nameof(ArticleBibliographies));

		builder.Property(p => p.ArticleId)
			.HasColumnName("ArticleId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.BibliographyId)
			.HasColumnName("BibliographyId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(1)
			.IsRequired(true);

		#region Keys and Foreignkeys
		builder.HasKey(k => new { k.ArticleId, k.BibliographyId });

		builder.HasOne(o => o.Article)
				.WithMany(m => m.Bibliographies)
				.HasForeignKey(f => f.ArticleId)
				.HasConstraintName("FK_ArticleBibliographies_Article_Id")
				.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(o => o.Bibliography)
			.WithMany(m => m.Articles)
			.HasForeignKey(f => f.BibliographyId)
			.HasConstraintName("FK_ArticleBibliographies_Bibliography_Id")
			.OnDelete(DeleteBehavior.NoAction);
		#endregion
	}
}
