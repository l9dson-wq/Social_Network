using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class CommentRepository : CommonRepository<Comment>, ICommentRepository
{
  private readonly ApplicationContext _dbContext;
    
  public CommentRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}