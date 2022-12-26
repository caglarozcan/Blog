using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

public class BibliographyReadRepository : ReadRepository<Bibliography>, IBibliographyReadRepository
{
	public BibliographyReadRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
