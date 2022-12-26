using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository;

internal class BibliographyWriteRepository : WriteRepository<Bibliography>, IBibliographyWriteRepository
{
	public BibliographyWriteRepository(DbContext dbContext) 
		: base(dbContext)
	{
	}
}
