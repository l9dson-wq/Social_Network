using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class UserProfileService : CommonService<SaveUserProfileViewModel, UserProfileViewModel, UserProfile>, IUserProfileService
{
  private readonly IUserProfileRepository _iUserProfileRepository;
  private readonly IMapper _iMapper;

  public UserProfileService(IUserProfileRepository iUserProfileRepository, IMapper iMapper) : base(iUserProfileRepository, iMapper)
  {
    _iUserProfileRepository = iUserProfileRepository;
    _iMapper = iMapper;
  }
  
  // THis is the method to log in the user
  public async Task<UserProfileViewModel> Login(LoginViewModel loginViewModel)
  {
    UserProfile userProfile = await _iUserProfileRepository.LoginAsync(loginViewModel);

    UserProfileViewModel userProfileViewModel = _iMapper.Map<UserProfileViewModel>(userProfile);

    return userProfileViewModel;
  }

  public async Task<List<UserProfileViewModel>> GetAllViewModelWithInclude()
  {
    List<UserProfile> users =
      await _iUserProfileRepository.GetAllWithIncludeAsync(new List<string> { "UserProfilePicture" });

    return users.Select(user => new UserProfileViewModel
    {
      Id = user.Id,
      UserName = user.UserName,
      Password = user.Password,
      About = user.About,
      Email = user.Email,
      Phone = user.Phone,
      ProfilePicturePath = user.UserProfilePicture.ProfilePicturePath,
      BackgroundPicturePath = user.UserProfilePicture.BackgroundPicturePath,
    }).ToList();
  }
  
  public async Task<UserProfileViewModel> GetViewModelWithInclude(int id)
  {
    List<UserProfile> users =
      await _iUserProfileRepository.GetAllWithIncludeAsync(new List<string> { "UserProfilePicture" });

    UserProfile userProfile = users.FirstOrDefault(user => user.Id == id );

    UserProfileViewModel userProfileViewModel = _iMapper.Map<UserProfileViewModel>(userProfile);
    userProfileViewModel.ProfilePicturePath = userProfile.UserProfilePicture.ProfilePicturePath;
    userProfileViewModel.BackgroundPicturePath = userProfile.UserProfilePicture.BackgroundPicturePath;

    return userProfileViewModel;
  }
}
