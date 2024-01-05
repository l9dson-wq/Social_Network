namespace Core.Domain;

public class Comment : AuditableBaseEntity
{
  public string Description { get; set; } = string.Empty;
  public string ImagePath { get; set; } = string.Empty;
  public int Reported { get; set; }

  //RELATIONS
  public int UserId { get; set; }
  public User User { get; set; }

  public int PostId { get; set; }
  public Post Post { get; set; }

  public int? ParentCommentId { get; set; }
  public Comment ParentComment { get; set; }

  public ICollection<Like> Likes { get; set; }
  public ICollection<Comment> Replies { get; set; }
}
