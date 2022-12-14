using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class UserRolesMap : IEntityTypeConfiguration<UserRoles>
{
	public void Configure(EntityTypeBuilder<UserRoles> builder)
	{
		builder.ToTable(nameof(UserRoles));

		builder.Property(p => p.UserId)
			.HasColumnName("UserId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.RoleId)
			.HasColumnName("RoleId")
			.HasColumnType("uniqueidentifier")
			.HasColumnOrder(1)
		.IsRequired(true);

		#region Keys and Foreignkeys
		builder.HasKey(k => new { k.UserId, k.RoleId });

		builder.HasOne(o => o.User)
				.WithMany(m => m.Roles)
				.HasForeignKey(f => f.UserId)
				.HasConstraintName("FK_UserRoles_User_Id");

		builder.HasOne(o => o.Role)
				.WithMany(m => m.Users)
				.HasForeignKey(f => f.RoleId)
				.HasConstraintName("FK_UserRoles_Role_Id");
		#endregion
	}
}
