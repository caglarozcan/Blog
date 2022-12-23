using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class CommentWriteRepository : WriteRepository<Comment>, ICommentWriteRepository
{
	public CommentWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
