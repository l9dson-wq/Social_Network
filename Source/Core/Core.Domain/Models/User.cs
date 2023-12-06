namespace Core.Domain;

public class User : AuditableBaseEntity
{
  public string Name { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public int Age { get; set; }
  public string Gender { get; set; } = string.Empty;
  public string Country { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;

  // RELATIONS
  public UserProfile UserProfile { get; set; }
  public ICollection<Like> Likes { get; set; }
  public ICollection<Post> Posts { get; set; }
  public ICollection<Saved> Saveds { get; set; }

  public ICollection<FriendShip> FriendShips { get; set; }
  public ICollection<FriendShip> IAmFriend { get; set; }
}