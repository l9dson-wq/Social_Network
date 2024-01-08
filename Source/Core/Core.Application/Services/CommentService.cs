using AutoMapper;
using Core.Application.ViewModels.Comments;
using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application;

public class CommentService : CommonService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
{
  private readonly ICommentRepository _iCommentRepository;
  private readonly IMapper _iMapper;
  private readonly IUserProfileService _iUserProfile;
  
  public CommentService(
    ICommentRepository iCommentRepository, 
    IMapper iMapper,
    IUserProfileService iUserProfile) : base(iCommentRepository, iMapper)
  {
    _iCommentRepository = iCommentRepository;
    _iMapper = iMapper;
    _iUserProfile = iUserProfile;
  }

  public async Task<List<CommentViewModel>> GetAllViewModelWithInclude()
  {
    var comments = await _iCommentRepository.
      GetAllWithIncludeAsync(new List<string>{"Likes","Replies","ParentComment","User"});

    var userProfiles = await _iUserProfile.GetAllViewModelWithInclude();
    
    var commentViewModels = comments.Select(comment => new CommentViewModel()
    {
      Id = comment.Id,
      Description = comment.Description,
      ImagePath = comment.ImagePath,
      UserId = comment.UserId,
      PostId = comment.PostId ?? 0,  // Si comment.PostId es null, se asigna 0 como valor predeterminado
      User = _iMapper.Map<UserViewModel>(comment.User),
      Post = _iMapper.Map<PostViewModel>(comment.Post),
      Likes = _iMapper.Map<List<LikeViewModel>>(comment.Likes),
      Replies = _iMapper.Map<List<CommentViewModel>>(comment.Replies),
      ParentComment = _iMapper.Map<CommentViewModel>(comment.ParentComment),
      ParentCommentId = comment.ParentCommentId,
      ParentCommentUsername = comment.ParentComment?.User?.UserProfile?.UserName,
      UserProfile = userProfiles.FirstOrDefault(userProfile => userProfile.UserId == comment.UserId),
    }).ToList();

    return commentViewModels;
  }
}