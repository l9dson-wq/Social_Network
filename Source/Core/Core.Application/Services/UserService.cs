using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class UserService : CommonService<SaveUserViewModel, UserViewModel, User>, IUserService
{
  private readonly IMapper _mapper;
  private readonly IUserRepository _iUserRepository;

  public UserService(IMapper mapper, IUserRepository iUserRepository) : base(iUserRepository, mapper)
  {
    _mapper = mapper;
    _iUserRepository = iUserRepository;
  }

  public async Task<List<UserViewModel>> GetAllViewModelWithInclude()
  {
    List<User> users = await _iUserRepository.GetAllWithIncludeAsync(new List<string> { "UserProfile" });

    return users.Select(user => new UserViewModel
    {
      Id = user.Id,
      Name = user.Name,
      LastName = user.LastName,
      Age = user.Age,
      Gender = user.Gender,
      Country = user.Country,
      City = user.City,
      UserName = user.UserProfile.UserName,
      About = user.UserProfile.About,
    }).ToList();
  }
}
