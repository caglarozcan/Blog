using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
{
	public CommentReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
