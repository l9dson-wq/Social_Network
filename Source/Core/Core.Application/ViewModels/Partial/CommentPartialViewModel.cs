using Core.Application.ViewModels.Comments;

namespace Core.Application.ViewModels.Partial;

public class CommentPartialViewModel
{
  public CommentViewModel? Comment { get; set; }
  public List<CommentViewModel>? Comments { get; set; }
  public UserProfileViewModel? UserProfile { get; set; }
  public SaveCommentViewModel? SaveComment { get; set; }
  public string? ReplyDescription { get; set; }
}