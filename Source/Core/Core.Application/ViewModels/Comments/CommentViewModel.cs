using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application.ViewModels.Comments;

public class CommentViewModel
{
  public int Id { get; set; }
  public string Description { get; set; }
  public string ImagePath { get; set; }
  public int UserId { get; set; }
  public int? ParentCommentId { get; set; }
  public UserViewModel User { get; set; }
  public PostViewModel Post { get; set; }
  public CommentViewModel ParentComment { get; set; }
  public ICollection<LikeViewModel> Likes { get; set; }
  public ICollection<CommentViewModel> Replies { get; set; }
  public int PostId { get; set; }
  public string ParentCommentUsername { get; set; }
  public UserProfileViewModel UserProfile { get; set; }
  public List<UserProfilePictureViewModel> UserProfilePictureViewModels { get; set; }
  public int? PrincipalPostCommentId { get; set; }
}