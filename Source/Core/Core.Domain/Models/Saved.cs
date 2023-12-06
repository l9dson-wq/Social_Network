namespace Core.Domain;

public class Saved
{
  public int Id { get; set; }
  public DateTime Date { get; set; }

  //RELATIONS
  public int UserId { get; set; }
  public User User { get; set; }

  public int? CommentId { get; set; }
  public Comment Comment { get; set; }

  public int? PostId { get; set; }
  public Post Post { get; set; }
}
