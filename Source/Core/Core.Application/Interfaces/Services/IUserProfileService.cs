using Core.Domain;

namespace Core.Application;

public interface IUserProfileService : ICommonService<SaveUserProfileViewModel, UserProfileViewModel, UserProfile>
{
  Task<List<UserProfileViewModel>> GetAllViewModelWithInclude();
}
