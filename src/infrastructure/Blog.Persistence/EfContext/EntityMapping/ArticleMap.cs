using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
	public void Configure(EntityTypeBuilder<Article> builder)
	{
		builder.ToTable(nameof(Article));

		builder.HasKey(k => k.Id).HasName("PK_Article_Id");

		builder.Property(p => p.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.ValueGeneratedOnAdd()
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.UserId)
			.HasColumnName("UserId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(1)
			.IsRequired(true);

		builder.Property(p => p.Title)
			.HasColumnName("Title")
			.HasColumnType("varchar(200)")
			.HasMaxLength(200)
			.HasColumnOrder(2)
			.IsRequired(true);

		builder.Property(p => p.Description)
			.HasColumnName("Description")
			.HasColumnType("varchar(500)")
			.HasMaxLength(500)
			.HasColumnOrder(3)
			.IsRequired(true);

		builder.Property(p => p.Content)
			.HasColumnName("Content")
			.HasColumnType("varchar(max)")
			.HasColumnOrder(4)
			.IsRequired(true);

		builder.Property(p => p.Hit)
			.HasColumnName("Hit")
			.HasColumnType("int")
			.HasColumnOrder(5)
			.HasDefaultValue(0)
			.IsRequired(true);

		builder.Property(p => p.IsPinned)
			.HasColumnName("IsPinned")
			.HasColumnType("bit")
			.HasColumnOrder(6)
			.HasDefaultValue(false)
			.IsRequired(true);

		builder.Property(p => p.CreatedDate)
			.HasColumnName("CreatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(7)
			.HasDefaultValueSql("GETDATE()")
			.IsRequired(true);

		builder.Property(p => p.UpdatedDate)
			.HasColumnName("UpdatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(8)
			.IsRequired(false);

		builder.Property(p => p.Slug)
			.HasColumnName("Slug")
			.HasColumnType("varchar(200)")
			.HasMaxLength(200)
			.HasColumnOrder(9)
			.IsRequired(true);

		builder.Property(p => p.Status)
			.HasColumnName("Status")
			.HasColumnType("tinyint")
			.HasColumnOrder(10)
			.HasDefaultValue(1)
			.IsRequired(true);

		#region Keys and Foreignkeys
		builder.HasOne(o => o.User)
				.WithMany(m => m.Articles)
				.HasForeignKey(f => f.UserId)
				.HasConstraintName("FK_Article_User_Id");
		#endregion
	}
}
