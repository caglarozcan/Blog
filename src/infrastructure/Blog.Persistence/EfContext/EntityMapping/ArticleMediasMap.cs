using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class ArticleMediasMap : IEntityTypeConfiguration<ArticleMedias>
	{
		public void Configure(EntityTypeBuilder<ArticleMedias> builder)
		{
			builder.ToTable(nameof(ArticleMedias));

			builder.Property(p => p.ArticleId)
				.HasColumnName("ArticleId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.MediaId)
				.HasColumnName("MediaId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
			.IsRequired(true);

			#region Keys and Foreignkeys
			builder.HasKey(k => new { k.ArticleId, k.MediaId });

			builder.HasOne(o => o.Article)
					.WithMany(m => m.Medias)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleMedias_Article_Id")
					.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(o => o.Media)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.MediaId)
					.HasConstraintName("FK_ArticleMedias_Media_Id")
					.OnDelete(DeleteBehavior.NoAction);
			#endregion
		}
	}
}
