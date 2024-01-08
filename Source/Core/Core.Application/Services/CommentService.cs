using AutoMapper;
using Core.Application.ViewModels.Comments;
using Core.Application.ViewModels.Post;
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

  public async Task<List<CommentViewModel>> GetAllViewModelWithInclude()
  {
    var comments = await _iCommentRepository.GetAllWithIncludeAsync(new List<string>{"Likes","Replies","ParentComment"});

    return comments.Select(comment => new CommentViewModel()
    {
      Id = comment.Id,
      Description = comment.Description,
      ImagePath = comment.ImagePath,
      userId = comment.UserId,
      PostId = comment.PostId ?? 0,  // Si comment.PostId es null, se asigna 0 como valor predeterminado
      User = _iMapper.Map<UserViewModel>(comment.User),
      Post = _iMapper.Map<PostViewModel>(comment.Post),
      Likes = _iMapper.Map<List<LikeViewModel>>(comment.Likes),
      Replies = _iMapper.Map<List<CommentViewModel>>(comment.Replies),
      ParentComment = _iMapper.Map<CommentViewModel>(comment.ParentComment),
    }).ToList();
  }
  
  public async Task<List<CommentViewModel>> CustomGetAllViewModelWithInclude()
  {
    var comments = await _iCommentRepository.GetAllWithIncludeAsync(new List<string>{"Likes","Replies","ParentComment"});

    return comments.Select(comment => new CommentViewModel()
    {
      Id = comment.Id,
      Description = comment.Description,
      ImagePath = comment.ImagePath,
      userId = comment.UserId,
      PostId = comment.PostId ?? 0,
      User = _iMapper.Map<UserViewModel>(comment.User),
      Post = _iMapper.Map<PostViewModel>(comment.Post),
      Likes = _iMapper.Map<List<LikeViewModel>>(comment.Likes),
      Replies = _iMapper.Map<List<CommentViewModel>>(comment.Replies),
      ParentComment = _iMapper.Map<CommentViewModel>(comment.ParentComment),
    }).ToList();
  }
}