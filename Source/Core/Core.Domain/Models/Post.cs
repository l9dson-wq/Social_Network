namespace Core.Domain;

public class Post : AuditableBaseEntity
{
  public string ImagePath { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Reported { get; set; }

  //RELATIONS
  public int UserId { get; set; }
  public User User { get; set; }

  public ICollection<Comment> Comments { get; set; }

  public ICollection<Like> Likes { get; set; }
}
