using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application.ViewModels.Comments;

public class CommentViewModel
{
  public int Id { get; set; }
  public string Description { get; set; }
  public string ImagePath { get; set; }
  public int userId { get; set; }
  public int? ParentCommentId { get; set; }
  public UserViewModel User { get; set; }
  public PostViewModel Post { get; set; }
  public CommentViewModel ParentComment { get; set; }
  public ICollection<LikeViewModel> Likes { get; set; }
  public ICollection<Comment> Replies { get; set; }
  public int UserId { get; set; }
  public int PostId { get; set; }
}