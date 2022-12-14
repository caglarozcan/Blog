using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
{
	public ArticleWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
