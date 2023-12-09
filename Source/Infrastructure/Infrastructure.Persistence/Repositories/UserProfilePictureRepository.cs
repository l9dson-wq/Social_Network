using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class UserProfilePictureRepository : CommonRepository<UserProfilePicture>, IUserProfilePictureRepository
{
  private readonly ApplicationContext _dbContext;

  public UserProfilePictureRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
