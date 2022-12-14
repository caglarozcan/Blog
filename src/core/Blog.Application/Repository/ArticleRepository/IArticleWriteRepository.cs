using Blog.Domain.Entities;

namespace Blog.Application.Repository;

public interface IArticleWriteRepository : IWriteRepository<Article>
{
}
