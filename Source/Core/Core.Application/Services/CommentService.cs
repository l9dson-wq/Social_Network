using AutoMapper;
using Core.Application.ViewModels.Comments;
using Core.Domain;

namespace Core.Application;

public class CommentService : CommonService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
{
  private readonly ICommentRepository _iCommentRepository;
  private readonly IMapper _iMapper;
  
  public CommentService(ICommentRepository iCommentRepository, IMapper iMapper) : base(iCommentRepository, iMapper)
  {
    _iCommentRepository = iCommentRepository;
    _iMapper = iMapper;
  }
}