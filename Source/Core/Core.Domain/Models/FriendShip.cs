namespace Core.Domain;

public class FriendShip
{
  public int Id { get; set; }
  public int Blocked { get; set; }
  public DateTime Date { get; set; }

  //RELATIONS
  public int UserId { get; set; }
  public User User { get; set; }

  public int FriendId { get; set; }
  public User Friend { get; set; }
}
