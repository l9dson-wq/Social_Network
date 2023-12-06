namespace Core.Domain;

public class Like
{
  public int Id { get; set; }
  public bool IsLike { get; set; }

  // RELATIONS
  public int UserId { get; set; }
  public User User { get; set; }

  public int? PostId { get; set; }
  public Post Post { get; set; }

  public int? CommentId { get; set; }
  public Comment Comment { get; set; }
}
