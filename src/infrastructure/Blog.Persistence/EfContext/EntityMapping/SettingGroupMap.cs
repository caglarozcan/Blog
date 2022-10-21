using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class SettingGroupMap : IEntityTypeConfiguration<SettingGroup>
	{
		public void Configure(EntityTypeBuilder<SettingGroup> builder)
		{
			builder.ToTable(nameof(SettingGroup));

			builder.HasKey(k => k.Id).HasName("PK_SettingGroup_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.Description)
				.HasColumnName("Description")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
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

			#region Keys and Foreignkeys
			builder.HasMany(m => m.Settings)
					.WithOne(o => o.SettingGroup)
					.HasForeignKey(f => f.SettingGroupId)
					.HasConstraintName("FK_Settings_SettingGroup_Id");
			#endregion
		}
	}
}
