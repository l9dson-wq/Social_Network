using Core.Domain;

namespace Core.Application;

public interface IUserProfileRepository : ICommonRepository<UserProfile>
{
    Task<UserProfile> AddAsync(UserProfile userProfile);
    Task<UserProfile> LoginAsync(LoginViewModel loginViewModel);
    Task<UserProfile> GetUserByUsername(string username);
}
