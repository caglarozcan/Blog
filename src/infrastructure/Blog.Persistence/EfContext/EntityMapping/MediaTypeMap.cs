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
				.HasColumnType("varchar(30)")
				.HasMaxLength(30)
				.HasColumnOrder(2)
				.IsRequired(true);
			
			builder.Property(p => p.FileExtension)
				.HasColumnName("FileExtension")
				.HasColumnType("varchar(5)")
				.HasMaxLength(5)
				.HasColumnOrder(3)
				.IsRequired(true);

			builder.Property(p => p.Icon)
				.HasColumnName("Icon")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(4)
				.IsRequired(true);

			builder.Property(p => p.Color)
				.HasColumnName("Color")
				.HasColumnType("varchar(10)")
				.HasMaxLength(10)
				.HasColumnOrder(5)
				.IsRequired(true);

			builder.Property(p => p.UploadDir)
				.HasColumnName("UploadDir")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.HasColumnOrder(6)
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

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(9)
				.HasDefaultValue(1)
				.IsRequired(true);
		}
	}
}
