using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class CommentMap : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.ToTable(nameof(Comment));

		builder.HasKey(k => k.Id).HasName("PK_Comment_Id");

		builder.Property(p => p.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.ValueGeneratedOnAdd()
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.ArticleId)
				.HasColumnName("Article")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
				.IsRequired(true);

		builder.Property(p => p.UserId)
			.HasColumnName("UserId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(2)
			.IsRequired(true);

		builder.Property(p => p.ParentCommentId)
			.HasColumnName("ParentCommentId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(3)
			.IsRequired(false);

		builder.Property(p => p.FirstName)
			.HasColumnName("FirstName")
			.HasColumnType("varchar(10)")
			.HasMaxLength(10)
			.HasColumnOrder(4)
			.IsRequired(true);

		builder.Property(p => p.LastName)
			.HasColumnName("LastName")
			.HasColumnType("varchar(10)")
			.HasMaxLength(10)
			.HasColumnOrder(5)
			.IsRequired(true);

		builder.Property(p => p.Email)
			.HasColumnName("Email")
			.HasColumnType("varchar(80)")
			.HasMaxLength(80)
			.HasColumnOrder(6)
			.IsRequired(true);

		builder.Property(p => p.Content)
			.HasColumnName("Content")
			.HasColumnType("varchar(1000)")
			.HasMaxLength(1000)
			.HasColumnOrder(7)
			.IsRequired(true);

		builder.Property(p => p.CreatedDate)
			.HasColumnName("CreatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(8)
			.HasDefaultValueSql("GETDATE()")
			.IsRequired(true);

		builder.Property(p => p.UpdatedDate)
			.HasColumnName("UpdatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(9)
			.IsRequired(false);

		builder.Property(p => p.Status)
			.HasColumnName("Status")
			.HasColumnType("tinyint")
			.HasColumnOrder(10)
			.HasDefaultValue(1)
			.IsRequired(true);

		#region Keys and Foreignkeys
		builder.HasOne(o => o.Article)
				.WithMany(m => m.Comments)
				.HasForeignKey(f => f.ArticleId)
				.HasConstraintName("FK_Comment_Article_Id")
				.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(o => o.User)
				.WithMany(m => m.Comments)
				.HasForeignKey(f => f.UserId)
				.HasConstraintName("FK_Comment_User_Id")
				.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(o => o.ParentComment)
				.WithMany(o => o.Childs)
				.HasForeignKey(f => f.ParentCommentId)
				.HasConstraintName("FK_Comment_Parent_Id")
				.OnDelete(DeleteBehavior.NoAction);
		#endregion
	}
}
