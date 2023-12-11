using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application;

public interface IPostService : ICommonService<SavePostViewModel, PostViewModel, Post>
{
  Task<List<PostViewModel>> GetAllViewModelWithInclude();
}
