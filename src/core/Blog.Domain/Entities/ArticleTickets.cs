namespace Blog.Domain.Entities;

public class ArticleTickets
{
    public Guid ArticleId { get; set; }

    public Guid TicketId { get; set; }

    public virtual Article Article { get; set; }

    public virtual Ticket Ticket { get; set; }
}
