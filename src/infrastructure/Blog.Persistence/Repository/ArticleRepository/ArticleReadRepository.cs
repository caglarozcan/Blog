using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
{
	public ArticleReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
