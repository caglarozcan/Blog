using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class TicketMap : IEntityTypeConfiguration<Ticket>
	{
		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.ToTable(nameof(Ticket));

			builder.HasKey(k => k.Id).HasName("PK_Ticket_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.Title)
				.HasColumnName("Title")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(1)
				.IsRequired(true);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(2)
				.HasDefaultValueSql("GETDATE()")
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(3)
				.IsRequired(false);

			builder.Property(p => p.Slug)
				.HasColumnName("Slug")
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(4)
				.IsRequired(true);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(5)
				.HasDefaultValue(1)
				.IsRequired(true);
		}
	}
}
