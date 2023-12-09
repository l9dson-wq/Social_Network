using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class UserProfilePictureService : CommonService<SaveUserProfilePictureViewModel, UserProfilePictureViewModel, UserProfilePicture>, IUserProfilePictureService
{
  private readonly IMapper _iMapper;
  private readonly IUserProfilePictureRepository _iUserProfilePictureRepository;

  public UserProfilePictureService(IUserProfilePictureRepository iUserProfilePictureRepository, IMapper iMapper) : base(iUserProfilePictureRepository, iMapper)
  {
    _iUserProfilePictureRepository = iUserProfilePictureRepository;
    _iMapper = iMapper;
  }
}
