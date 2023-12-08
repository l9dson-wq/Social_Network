using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class UserProfileRepository : CommonRepository<UserProfile>, IUserProfileRepository
{
  private readonly ApplicationContext _dbContext;

  public UserProfileRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
