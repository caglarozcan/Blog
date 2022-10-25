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

			#region Seed Data
			/*builder.HasData(
				new SettingGroup()
				{
					Id = Guid.NewGuid(),
					Name = "Genel Site",
					Description = "Genel site seçenekleri.",
					CreatedDate = DateTime.Now,
					Status = 1,
					Settings = new List<Settings>()
					{
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Site URL",
							Value = "https://localhost:9000/",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Site Başlığı",
							Value = "Simple Blog",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Site Slogan",
							Value = "Yazılım günlüğüm.",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Site Açıklama",
							Value = "Yazılım deneyimlerimi paylaştığım blog sitem.",
							CreatedDate = DateTime.Now,
							Status = 1
						}
					}
				},
				new SettingGroup()
				{
					Name = "Dosya Yükleme",
					Description = "Resim dosyası yükleme seçenekleri.",
					CreatedDate = DateTime.Now,
					Status = 1,
					Settings = new List<Settings>()
					{
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Dosya Yükleme Yeri (Genel Dizin)",
							Value = "uploads/images",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Dizin Şekli",
							Value = "1",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Küçük Resim",
							Value = "150x150",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Orta Resim",
							Value = "500x500",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "Büyük Resim",
							Value = "1024x1024",
							CreatedDate = DateTime.Now,
							Status = 1
						}
					}
				},
				new SettingGroup()
				{
					Id = Guid.NewGuid(),
					Name = "E-Posta",
					Description = "E-Posta gönderimi için ayarlar.",
					CreatedDate = DateTime.Now,
					Status = 1,
					Settings = new List<Settings>()
					{
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "E-Posta Sunucusu\r\n",
							Value = "smtp.caglarozcan.com.tr",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "E-Posta Adresi",
							Value = "mail@caglarozcan.com.tr",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "E-Posta Şifresi",
							Value = "*****",
							CreatedDate = DateTime.Now,
							Status = 1
						},
						new Settings()
						{
							Id = Guid.NewGuid(),
							Name = "E-Posta Sunucu Port Numarası",
							Value = "512",
							CreatedDate = DateTime.Now,
							Status = 1
						}
					}
				});*/
			#endregion
		}
	}
}
