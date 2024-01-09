using Core.Application;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UserProfileRepository : CommonRepository<UserProfile>, IUserProfileRepository
{
  private readonly ApplicationContext _dbContext;

  public UserProfileRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public override async Task<UserProfile> AddAsync(UserProfile userProfile)
  {
    userProfile.Password = PasswordEncryption.ComputeSha256Hash(userProfile.Password);
    return await base.AddAsync(userProfile);
  }

  public async Task<UserProfile> LoginAsync(LoginViewModel loginViewModel)
  {
    string passwordEncrypt = PasswordEncryption.ComputeSha256Hash(loginViewModel.Password);

    UserProfile userProfile = await _dbContext
      .Set<UserProfile>()
      .FirstOrDefaultAsync(userProfile => userProfile.UserName == loginViewModel.Username && userProfile.Password == passwordEncrypt);

    return userProfile;
  }

  public async Task<UserProfile> GetUserByUsername(string username)
  {
    var userProfile = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(userPRofile => userPRofile.UserName == username);

    return userProfile;
  }
}
