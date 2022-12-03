using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class SettingsMap : IEntityTypeConfiguration<Settings>
	{
		public void Configure(EntityTypeBuilder<Settings> builder)
		{
			builder.ToTable(nameof(Settings));

			builder.HasKey(k => k.Id).HasName("PK_Settings_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.SettingGroupId)
				.HasColumnName("SettingGroupId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.Value)
				.HasColumnName("Value")
				.HasColumnType("varchar(250)")
				.HasMaxLength(250)
				.HasColumnOrder(3)
				.IsRequired(true);

			builder.Property(p => p.SettingKey)
				.HasColumnName("SettingKey")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(4)
				.IsRequired(true);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(5)
				.HasDefaultValueSql("GETDATE()")
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(6)
				.IsRequired(false);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(7)
				.HasDefaultValue(1)
				.IsRequired(true);
		}
	}
}
