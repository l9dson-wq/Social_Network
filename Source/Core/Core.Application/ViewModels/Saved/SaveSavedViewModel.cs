namespace Core.Application.ViewModels.Saved;

public class SaveSavedViewModel
{
  public int Id { get; set; }
  public DateTime Date { get; set; }

  //RELATIONS
  public int UserId { get; set; }

  public int? CommentId { get; set; }

  public int? PostId { get; set; }
}