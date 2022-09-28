using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class ArticleTicketsMap : IEntityTypeConfiguration<ArticleTickets>
	{
		public void Configure(EntityTypeBuilder<ArticleTickets> builder)
		{
			builder.ToTable(nameof(ArticleTickets));

			builder.Property(p => p.ArticleId)
				.HasColumnName("ArticleId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.TicketId)
				.HasColumnName("TicketId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
				.IsRequired(true);

			#region Keys and Foreignkeys
			builder.HasKey(k => new { k.ArticleId, k.TicketId });

			builder.HasOne(o => o.Article)
					.WithMany(m => m.Tickets)
					.HasForeignKey(f => f.ArticleId)
					.HasConstraintName("FK_ArticleTickets_Article_Id");

			builder.HasOne(o => o.Ticket)
					.WithMany(m => m.Articles)
					.HasForeignKey(f => f.TicketId)
					.HasConstraintName("FK_ArticleTickets_Ticket_Id");
			#endregion
		}
	}
}
