using Core.Domain;

namespace Core.Application;

public interface IUserService : ICommonService<SaveUserViewModel, UserViewModel, User>
{
  Task<List<UserViewModel>> GetAllViewModelWithInclude();
}
