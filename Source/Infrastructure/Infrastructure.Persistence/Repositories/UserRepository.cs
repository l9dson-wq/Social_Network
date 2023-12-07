using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class UserRepository : CommonRepository<User>, IUserRepository
{
  private readonly ApplicationContext _dbContext;

  public UserRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
