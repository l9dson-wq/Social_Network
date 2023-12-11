using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class PostRepository : CommonRepository<Post>, IPostRepository
{
  private readonly ApplicationContext _dbContext;

  public PostRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
