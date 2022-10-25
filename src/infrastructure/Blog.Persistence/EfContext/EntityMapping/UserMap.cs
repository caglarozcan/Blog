using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable(nameof(User));

			builder.HasKey(k => k.Id).HasName("PK_User_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.Name)
				.HasColumnName("Name")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.LastName)
				.HasColumnName("LastName")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.NickName)
				.HasColumnName("NickName")
				.HasColumnType("varchar(10)")
				.HasMaxLength(10)
				.HasColumnOrder(3)
				.IsRequired(true);

			builder.Property(p => p.Email)
				.HasColumnName("Email")
				.HasColumnType("varchar(150)")
				.HasMaxLength(150)
				.HasColumnOrder(4)
				.IsRequired(true);

			builder.Property(p => p.Password)
				.HasColumnName("Password")
				.HasColumnType("varchar(300)")
				.HasMaxLength(300)
				.HasColumnOrder(5)
				.IsRequired(true);

			builder.Property(p => p.LastLogin)
				.HasColumnName("LastLogin")
				.HasColumnType("datetime")
				.HasColumnOrder(6)
				.IsRequired(false);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasDefaultValueSql("GETDATE()")
				.HasColumnOrder(7)
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(8)
				.IsRequired(false);

			builder.Property(p => p.Slug)
				.HasColumnName("Slug")
				.HasColumnType("varchar(40)")
				.HasMaxLength(40)
				.HasColumnOrder(9)
				.IsRequired(true);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(10)
				.HasDefaultValue(1)
				.IsRequired(true);

			#region Seed Data
			/*builder.HasData(new User()
			{
				CreatedDate = DateTime.Now,
				Email = "cglrozcan@gmail.com",
				Name = "Çağlar",
				LastName = "ÖZCAN",
				NickName = "cahoo",
				Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", //: 123456
				Slug = "caglar-ozcan",
				Status = 1
			});*/
			#endregion
		}
	}
}
