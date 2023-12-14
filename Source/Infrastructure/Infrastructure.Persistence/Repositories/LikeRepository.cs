using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class LikeRepository : CommonRepository<Like>, ILikeRepository
{
  private readonly ApplicationContext _dbContext;

  public LikeRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
