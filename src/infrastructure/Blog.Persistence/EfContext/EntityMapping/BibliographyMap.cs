using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class BibliographyMap : IEntityTypeConfiguration<Bibliography>
{
	public void Configure(EntityTypeBuilder<Bibliography> builder)
	{
		builder.ToTable(nameof(Bibliography));

		builder.HasKey(k => k.Id).HasName("PK_Bibliography_id");

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

		builder.Property(p => p.Url)
			.HasColumnName("Url")
			.HasColumnType("varchar(500)")
			.HasMaxLength(500)
			.HasColumnOrder(3)
			.IsRequired(true);

		builder.Property(p => p.CreatedDate)
			.HasColumnName("CreatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(4)
			.HasDefaultValueSql("GETDATE()")
			.IsRequired(true);

		builder.Property(p => p.UpdatedDate)
			.HasColumnName("UpdatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(5)
			.IsRequired(false);

		builder.Property(p => p.Status)
			.HasColumnName("Status")
			.HasColumnType("tinyint")
			.HasColumnOrder(6)
			.HasDefaultValue(1)
			.IsRequired(true);

		#region Keys and Foreignkeys
		builder.HasOne(o => o.User)
				.WithMany(m => m.Bibliographies)
				.HasForeignKey(f => f.UserId)
				.HasConstraintName("FK_Bibliography_User_Id");
		#endregion
	}
}
