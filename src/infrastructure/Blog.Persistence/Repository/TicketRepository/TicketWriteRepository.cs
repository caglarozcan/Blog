using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class TicketWriteRepository : WriteRepository<Ticket>, ITicketWriteRepository
	{
		public TicketWriteRepository(DbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
