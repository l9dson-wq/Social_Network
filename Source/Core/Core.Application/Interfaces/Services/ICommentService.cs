using Core.Application.ViewModels.Comments;
using Core.Domain;

namespace Core.Application;

public interface ICommentService : ICommonService<SaveCommentViewModel, CommentViewModel, Comment>
{
  Task<List<CommentViewModel>> GetAllViewModelWithInclude();
}