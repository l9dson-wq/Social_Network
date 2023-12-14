namespace Core.Application;

public class SaveLikeViewModel
{

  public int Id { get; set; }
  public bool IsLike { get; set; }

  // RELATIONS
  public int UserId { get; set; }

  public int? PostId { get; set; }

  public int? CommentId { get; set; }
}
