using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class MediaMap : IEntityTypeConfiguration<Media>
	{
		public void Configure(EntityTypeBuilder<Media> builder)
		{
			builder.ToTable(nameof(Media));

			builder.HasKey(k => k.Id).HasName("PK_Media_Id");

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

			builder.Property(p => p.MediaTypeId)
				.HasColumnName("MediaTypeId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.HasColumnOrder(3)
				.IsRequired(true);

			builder.Property(p => p.OriginalName)
				.HasColumnName("OriginalName")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.HasColumnOrder(4)
				.IsRequired(true);

			builder.Property(p => p.Description)
				.HasColumnName("Description")
				.HasColumnType("varchar(500)")
				.HasMaxLength(500)
				.HasColumnOrder(5)
				.IsRequired(true);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(6)
				.HasDefaultValueSql("GETDATE()")
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(7)
				.IsRequired(false);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(8)
				.HasDefaultValue(1)
				.IsRequired(true);

			#region Keys and Foreignkeys
			builder.HasOne(o => o.User)
					.WithMany(m => m.Medias)
					.HasForeignKey(f => f.UserId)
					.HasConstraintName("FK_Media_User_Id");

			builder.HasOne(o => o.MediaType)
				.WithMany(m => m.Medias)
				.HasForeignKey(f => f.MediaTypeId)
				.HasConstraintName("FK_Media_MediaType_Id");
			#endregion
		}
	}
}
