using Core.Application.ViewModels.Post;

namespace Core.Application.ViewModels.Comments;

public class CommentViewModel
{
  public int Id { get; set; }
  public string Description { get; set; }
  public string ImagePath { get; set; }
  public int userId { get; set; }
  public UserViewModel User { get; set; }
  public PostViewModel Post { get; set; }
  public ICollection<LikeViewModel> Likes { get; set; }
  public int UserId { get; set; }
  public int PostId { get; set; }
}