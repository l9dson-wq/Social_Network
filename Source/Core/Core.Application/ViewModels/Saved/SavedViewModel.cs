using Core.Application.ViewModels.Post;

namespace Core.Application.ViewModels.Saved;

public class SavedViewModel
{
  public int Id { get; set; }
  public DateTime Date { get; set; }

  //RELATIONS
  public int UserId { get; set; }
  public UserViewModel User { get; set; }

  public int? CommentId { get; set; }

  public int? PostId { get; set; }
  public SavePostViewModel Post { get; set; }
}