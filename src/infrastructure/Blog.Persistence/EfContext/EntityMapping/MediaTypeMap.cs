using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class MediaTypeMap : IEntityTypeConfiguration<MediaType>
	{
		public void Configure(EntityTypeBuilder<MediaType> builder)
		{
			builder.ToTable(nameof(MediaType));

			builder.HasKey(k => k.Id).HasName("PK_MediaType_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.Title)
				.HasColumnName("Title")
				.HasColumnType("varchar(50)")
				.HasMaxLength(50)
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.MimeType)
				.HasColumnName("MimeType")
				.HasColumnType("varchar(10)")
				.HasMaxLength(10)
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(3)
				.HasDefaultValueSql("GETDATE()")
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(4)
				.IsRequired(false);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(5)
				.HasDefaultValue(1)
				.IsRequired(true);
		}
	}
}
