using Core.Domain;

namespace Core.Application;

public interface IUserProfileService : ICommonService<SaveUserProfileViewModel, UserProfileViewModel, UserProfile>
{
  Task<List<UserProfileViewModel>> GetAllViewModelWithInclude();
  Task<UserProfileViewModel> Login(LoginViewModel loginViewModel);
  Task<UserProfileViewModel> GetViewModelWithInclude(int id);
}
