using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class UserService : CommonService<SaveUserViewModel, UserViewModel, User>, IUserService
{
  private readonly IMapper _mapper;
  private readonly IUserRepository _iUserRepository;
  private readonly IUserProfileService _iUserProfileService;

  public UserService(IMapper mapper, IUserRepository iUserRepository, IUserProfileService iUserProfileService) : base(iUserRepository, mapper)
  {
    _mapper = mapper;
    _iUserRepository = iUserRepository;
    _iUserProfileService = iUserProfileService;
  }

  public async Task<List<UserViewModel>> GetAllViewModelWithInclude()
  {
    var users = await _iUserRepository.GetAllWithIncludeAsync(new List<string> { "UserProfile", "Posts" });

    return users.Select(user => new UserViewModel
    {
      Id = user.Id,
      Name = user.Name,
      LastName = user.LastName,
      Age = user.Age,
      Gender = user.Gender,
      Country = user.Country,
      City = user.City,
      Posts = user.Posts,
    }).ToList();
  }
}
