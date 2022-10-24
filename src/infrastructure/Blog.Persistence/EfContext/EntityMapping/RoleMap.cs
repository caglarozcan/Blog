using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class RoleMap : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable(nameof(Role));

			builder.HasKey(k => k.Id).HasName("PK_Role_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(15)")
				.HasMaxLength(15)
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.Description)
				.HasColumnName("Description")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.CanLogin)
				.HasColumnName("CanLogin")
				.HasColumnType("bit")
				.HasColumnOrder(3)
				.HasDefaultValue(true)
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

			#region Seed Data
			builder.HasData(
				new Role()
				{
					CanLogin = true,
					CreatedDate = DateTime.Now,
					Description = "Admin Kullanıcısı",
					Name = "Administrator",
					Status = 1
				},
				new Role()
				{
					CanLogin = true,
					CreatedDate = DateTime.Now,
					Description = "Editör Kullanıcısı",
					Name = "Editör",
					Status = 1
				},
				new Role()
				{
					CanLogin = true,
					CreatedDate = DateTime.Now,
					Description = "Yazar Kullanıcısı",
					Name = "Yazar",
					Status = 1
				}
			);
			#endregion
		}
	}
}
