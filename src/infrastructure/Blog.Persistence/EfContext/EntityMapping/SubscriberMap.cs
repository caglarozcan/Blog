using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class SubscriberMap : IEntityTypeConfiguration<Subscriber>
{
	public void Configure(EntityTypeBuilder<Subscriber> builder)
	{
		builder.ToTable(nameof(Subscriber));

		builder.HasKey(k => k.Id).HasName("PK_Subscriber_Id");

		builder.Property(p => p.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.ValueGeneratedOnAdd()
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.FirsName)
			.HasColumnName("FirsName")
			.HasColumnType("varchar(10)")
			.HasMaxLength(10)
			.HasColumnOrder(1)
			.IsRequired(true);

		builder.Property(p => p.LastName)
			.HasColumnName("LastName")
			.HasColumnType("varchar(10)")
			.HasMaxLength(10)
			.HasColumnOrder(2)
			.IsRequired(true);

		builder.Property(p => p.Email)
			.HasColumnName("Email")
			.HasColumnType("varchar(100)")
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
	}
}
